using Microsoft.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder().AddUserSecrets<Program>();
var configuration = builder.Build();

using var dbContext = new TestDbContext(configuration["ConnectionStrings:SqlServer"]!);
await dbContext.Database.EnsureDeletedAsync();
await dbContext.Database.EnsureCreatedAsync();

var blogs = new[] {
    new Blog
    {
        Description = "This is a blog about AI and machine learning.",
        Embedding = new SqlVector<float>(new float[] { 0.1f, 0.2f, 0.3f })
    },
    new Blog
    {
        Description = "This is a blog about animals and plants.",
        Embedding = new SqlVector < float >(new float[] { 99.1f, 50f, 3f }),
    },
    new Blog
    {
        Description = "This is a blog about sports and outdoor activities.",
        Embedding = new SqlVector < float >(new float[] { 3f, 60f, 240f }),
    }
};

dbContext.Blogs.AddRange(blogs);
await dbContext.SaveChangesAsync();

var queryEmbedding = new SqlVector<float>(new float[] { 0.1f, 0.2f, 0.3f });

var query = dbContext.Blogs
    .OrderBy(p => EF.Functions.VectorDistance("cosine", p.Embedding, queryEmbedding))
    .Take(5);

foreach (var result in await query.ToArrayAsync())
{
    Console.WriteLine($"Similar blog ID: {result.Id}, Description: {result.Description}");
}

public class Blog
{
    public int Id { get; set; }

    public required string Description { get; set; }

    public SqlVector<float> Embedding { get; set; }
}

public class TestDbContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Blog> Blogs { get; set; } = null!;

    public TestDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);

        //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
        //    .EnableSensitiveDataLogging()
        //    .EnableDetailedErrors();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().Property(p => p.Embedding).HasColumnType("vector(3)");
    }
}
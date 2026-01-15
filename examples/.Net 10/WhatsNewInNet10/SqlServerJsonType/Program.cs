using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder().AddUserSecrets<Program>();
var configuration = builder.Build();

using var dbContext = new TestDbContext(configuration["ConnectionStrings:SqlServer"]!);
await dbContext.Database.EnsureDeletedAsync();
await dbContext.Database.EnsureCreatedAsync();

var highlyViewedBlogs = await dbContext.Blogs.Where(b => b.Details.Viewers > 3).ToListAsync();

foreach (var result in highlyViewedBlogs)
{
    Console.WriteLine($"Blog ID: {result.Id}");
}

public class Blog
{
    public int Id { get; set; }

    public string[] Tags { get; set; }

    public required BlogDetails Details { get; set; }
}

public class BlogDetails
{
    public string? Description { get; set; }

    public int Viewers { get; set; }
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
        optionsBuilder.UseSqlServer(_connectionString, opt =>
        {
            opt.UseCompatibilityLevel(170);
        });

        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().ComplexProperty(b => b.Details, b => b.ToJson());
    }
}
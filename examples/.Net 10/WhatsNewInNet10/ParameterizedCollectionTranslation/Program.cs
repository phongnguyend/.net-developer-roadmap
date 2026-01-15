using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder().AddUserSecrets<Program>();
var configuration = builder.Build();

using var context = new TestDbContext(configuration["ConnectionStrings:SqlServer"]!);
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

int[] ids = [1, 2, 3];

var blogs = await context.Blogs.Where(b => ids.Contains(b.Id)).ToListAsync();
var blogs1 = await context.Blogs.Where(b => EF.Constant(ids).Contains(b.Id)).ToListAsync();
var blogs2 = await context.Blogs.Where(b => EF.Parameter(ids).Contains(b.Id)).ToListAsync();
var blogs3 = await context.Blogs.Where(b => EF.MultipleParameters(ids).Contains(b.Id)).ToListAsync();

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
            opt.UseParameterizedCollectionMode(ParameterTranslationMode.Constant);
        });

        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().ComplexProperty(b => b.Details);
    }
}
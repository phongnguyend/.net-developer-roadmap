using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder().AddUserSecrets<Program>();
var configuration = builder.Build();

using var context = new TestDbContext(configuration["ConnectionStrings:SqlServer"]!);
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

await context.Blogs.ExecuteUpdateAsync(s =>
    s.SetProperty(b => b.Details.Views, b => b.Details.Views + 1));

public class Blog
{
    public int Id { get; set; }

    public string[] Tags { get; set; }

    public required BlogDetails Details { get; set; }
}

public class BlogDetails
{
    public string? Description { get; set; }

    public int Views { get; set; }
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
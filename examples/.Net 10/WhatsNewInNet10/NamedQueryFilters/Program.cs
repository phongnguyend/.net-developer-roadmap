using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder().AddUserSecrets<Program>();
var configuration = builder.Build();

using var context = new TestDbContext(configuration["ConnectionStrings:SqlServer"]!);
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

_ = context.Blogs.ToList();

_ = context.Blogs.IgnoreQueryFilters().ToList();

_ = context.Blogs.IgnoreQueryFilters(["SoftDeletionFilter"]).ToList();

_ = context.Blogs.IgnoreQueryFilters(["TenantFilter"]).ToList();

_ = context.Blogs.IgnoreQueryFilters(["SoftDeletionFilter", "TenantFilter"]).ToList();

public class Blog
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool IsDeleted { get; set; }

    public int TenantId { get; set; }
}

public class TestDbContext : DbContext
{
    private readonly string _connectionString;
    private readonly int tenantId = 1;

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
#if NET9_0
        modelBuilder.Entity<Blog>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Blog>().HasQueryFilter(b => b.TenantId == tenantId);
#endif
#if NET10_0
        modelBuilder.Entity<Blog>().HasQueryFilter("SoftDeletionFilter", b => !b.IsDeleted);
        modelBuilder.Entity<Blog>().HasQueryFilter("TenantFilter", b => b.TenantId == tenantId);
#endif
    }
}
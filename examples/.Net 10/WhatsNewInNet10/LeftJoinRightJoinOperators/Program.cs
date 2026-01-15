using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder().AddUserSecrets<Program>();
var configuration = builder.Build();

using var context = new TestDbContext(configuration["ConnectionStrings:SqlServer"]!);
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

// Left Join using GroupJoin and DefaultIfEmpty
_ = (from student in context.Students
     join department in context.Departments on student.DepartmentId equals department.Id into gj
     from subgroup in gj.DefaultIfEmpty()
     select new
     {
         student.FirstName,
         student.LastName,
         Department = subgroup.Name ?? "[NONE]"
     }).ToList();

// Left Join using LeftJoin
_ = context.Students
    .LeftJoin(
        context.Departments,
        student => student.DepartmentId,
        department => department.Id,
        (student, department) => new
        {
            student.FirstName,
            student.LastName,
            Department = department!.Name ?? "[NONE]"
        }
    ).ToList();

// Right Join using RightJoin
_ = context.Students
    .RightJoin(
        context.Departments,
        student => student.DepartmentId,
        department => department.Id,
        (student, department) => new
        {
            FirstName = student!.FirstName ?? "[NONE]",
            LastName = student!.LastName ?? "[NONE]",
            Department = department.Name
        }
    ).ToList();

public class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int DepartmentId { get; set; }
}

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; }
}

public class TestDbContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Student> Students { get; set; } = null!;

    public DbSet<Department> Departments { get; set; } = null!;

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
    }
}
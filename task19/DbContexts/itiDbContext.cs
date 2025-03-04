using System.Reflection;
using EF03.Models;
using Microsoft.EntityFrameworkCore;

namespace EF03.DbContexts;

public class ItiDbContext : DbContext
{
    public ItiDbContext() : base()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=ITI;User Id=sa;Password=AaBb12!@;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<CourseInstructor> CourseInstructors { get; set; }
}
using System.Reflection;
using ConsoleApp1.ModelConfigurations;
using ConsoleApp1.models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.DbContexts;

public class ITIDbContext : DbContext
{
    public ITIDbContext() : base()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=ITI;User Id=sa;Password=AaBb12!@;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new studentConf());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<student> students { get; set; }
    public DbSet<course> cources { get; set; }
    public DbSet<stud_course> stud_cources { get; set; }
    public DbSet<department> departments { get; set; }
    public DbSet<topic> topics { get; set; }
    public DbSet<course_inst> course_insts { get; set; }
    public DbSet<instructor> instructors { get; set; }

}
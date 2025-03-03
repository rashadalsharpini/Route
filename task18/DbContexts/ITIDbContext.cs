using ConsoleApp2.models;

namespace ConsoleApp2.DbContexts;
using Microsoft.EntityFrameworkCore;

public class ITIDbContext: DbContext
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
        modelBuilder.Entity<Department>().Property(d => d.Name).HasColumnType("VARCHAR(50)");
        modelBuilder.Entity<Instructor>().Property(i => i.Bonus).HasColumnType("DECIMAL(18,2)");
    }
    public DbSet<student> students { get; set; }
    public DbSet<course> cources { get; set; }
    public DbSet<stud_course> stud_cources { get; set; }
    public DbSet<department> departments { get; set; }
    public DbSet<topic> topics { get; set; }
    public DbSet<course_inst> course_insts { get; set; }
    public DbSet<instructor> instructors { get; set; }
}

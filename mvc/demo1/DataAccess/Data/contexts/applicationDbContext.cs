using System.Reflection;

namespace DataAccess.Data.contexts;

public class applicationDbContext(DbContextOptions<applicationDbContext> options) : DbContext(options)
{
    public DbSet<Department> Departments { get; set; }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer("connectionstring");
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(applicationDbContext).Assembly);
    }
}
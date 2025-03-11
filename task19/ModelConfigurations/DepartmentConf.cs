using EF03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF03.ModelConfgurations;

public class DepartmentConf : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        
        // i don't know that much about OnDelete but
        // i had an error because sqlServer wouldn't allow to multiple cascade paths
        // it said it will cause a loop
        builder.HasMany(d => d.Instructors)
            .WithOne(i=>i.Department)
            .HasForeignKey(i=>i.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.Manager)
            .WithOne()
            .HasForeignKey<Department>(d => d.ManagerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
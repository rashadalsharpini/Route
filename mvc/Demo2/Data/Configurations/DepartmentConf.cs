using Data.Models.Department;

namespace Data.Configurations;

public class DepartmentConf : BaseEntityConf<Department>, IEntityTypeConfiguration<Department>
{
    public new void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(d => d.Id).UseIdentityColumn(10, 10);
        builder.Property(d => d.DepartmentName).HasColumnType("varchar(20)");
        builder.Property(d => d.Code).HasColumnType("varchar(20)").IsRequired();
        // builder.HasIndex(d => d.Code).IsUnique();
        builder.HasQueryFilter(d => !d.IsDeleted);
        base.Configure(builder);
    }
}
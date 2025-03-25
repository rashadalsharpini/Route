namespace DataAccess.Data.Configurations;

public class DepartmentConf : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(d => d.id).UseIdentityColumn(10, 10);
        builder.Property(d => d.DepartmentName).HasColumnType("varchar(20");
        builder.Property(d => d.Code).HasColumnType("varchar(20");
        builder.Property(d=>d.createdOn).HasDefaultValueSql("GETDATE()");
        builder.Property(d=>d.lastModifiedOn).HasComputedColumnSql("GETDATE()");
    }
}
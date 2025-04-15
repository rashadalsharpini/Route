namespace Data.Configurations;

public class BaseEntityConf<T>:IEntityTypeConfiguration<T> where T:BaseEntity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(d=>d.CreatedOn).HasDefaultValueSql("GETDATE()");
        builder.Property(d=>d.LastModifiedOn).HasComputedColumnSql("GETDATE()");
    }
}
using Domain.Models.OrderModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

internal class OrderConf:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.Property(o => o.SubTotal)
            .HasColumnType("decimal(8,2)");
        builder.HasMany(o => o.Items)
            .WithOne()
            .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
        builder.HasOne(o => o.DeliveryMethod)
            .WithMany()
            .HasForeignKey(o => o.DeliveryMethodId);
        builder.OwnsOne(o => o.ShipToAddress);
    }
}
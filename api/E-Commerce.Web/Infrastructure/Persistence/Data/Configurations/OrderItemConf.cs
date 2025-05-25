using Domain.Models.OrderModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

internal class OrderItemConf:IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");
        builder.Property(oi => oi.Price)
            .HasColumnType("decimal(8,2)");
        builder.OwnsOne(oi => oi.Product);
    }
}
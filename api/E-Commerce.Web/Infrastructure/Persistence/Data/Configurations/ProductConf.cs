using Domain.Models.productModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

class ProductConf:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(p => p.ProductBrand).WithMany().HasForeignKey(p => p.BrandId);
        builder.HasOne(p => p.ProductType).WithMany().HasForeignKey(p => p.TypeId);
        builder.Property(p=>p.Price).HasColumnType("decimal(10,2)");
    }
}
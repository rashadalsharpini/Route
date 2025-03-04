using ConsoleApp1.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.ModelConfigurations;

public class courseConf : IEntityTypeConfiguration<course>
{
    public void Configure(EntityTypeBuilder<course> builder)
    {
        builder.Property(s => s.name).IsRequired();
        builder.Property(s => s.description).HasDefaultValue(" ");
    }
}
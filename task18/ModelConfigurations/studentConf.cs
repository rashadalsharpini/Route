using ConsoleApp1.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.ModelConfigurations;

public class studentConf : IEntityTypeConfiguration<student>
{
    public void Configure(EntityTypeBuilder<student> builder)
    {
        builder.HasKey(s=>s.id);
        builder.Property(s => s.fname).HasColumnType("varchar").HasMaxLength(50);
        builder.Property(s => s.lname).HasColumnType("varchar").HasMaxLength(50);
        builder.Property(s=>s.address).HasColumnName("student_address");
        builder.Property(s => s.age).IsRequired();
    }
}
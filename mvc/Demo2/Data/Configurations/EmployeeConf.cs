using Data.Models.Employee;
using Data.Models.Shared.Enums;

namespace Data.Configurations;

public class EmployeeConf : BaseEntityConf<Employee>, IEntityTypeConfiguration<Employee>
{
    public new void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
        builder.Property(e=>e.Address).HasColumnType("VARCHAR(150)");
        builder.Property(e=>e.Salary).HasColumnType("DECIMAL(10,2)");
        builder.Property(e=>e.Gender).HasConversion(empGender => empGender.ToString(),
            empGender=>(Gender)Enum.Parse(typeof(Gender), empGender));
        builder.Property(e=>e.Type).HasConversion(empType=>empType.ToString(),
            empType => (EmployeeType)Enum.Parse(typeof(EmployeeType), empType));
        base.Configure(builder);
    }
}
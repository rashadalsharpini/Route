using Data.Models.Shared.Enums;

namespace Data.Models.Employee;

public class Employee : BaseEntity
{
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string? Address { get; set; } = null!;
    public double Salary { get; set; }
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public string? ImageUrl { get; set; } = null!;
    public Gender Gender { get; set; }
    public EmployeeType Type { get; set; }
    public bool IsActive { get; set; }
    
    public int? DepartmentId { get; set; }
    public virtual Department.Department Department { get; set; }
}
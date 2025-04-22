using Data.Models.Shared;

namespace Data.Models.Department;

public class Department : BaseEntity
{
    public string DepartmentName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    
    public virtual ICollection<Employee.Employee> Employees { get; set; } = new HashSet<Employee.Employee>();
}
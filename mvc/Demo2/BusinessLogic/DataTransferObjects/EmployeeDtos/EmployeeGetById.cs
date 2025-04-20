using Data.Models.Employee;
using Data.Models.Shared.Enums;

namespace BusinessLogic.DataTransferObjects.EmployeeDtos;

public class EmployeeGetById
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsActive { get; set; }
    public string? Address { get; set; }
    public double Salary { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Gender { get; set; }
    public string Type { get; set; }
    public DateOnly HireDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; } = string.Empty;
    public DateTime LastModifiedOn { get; set; }
    public int? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
}
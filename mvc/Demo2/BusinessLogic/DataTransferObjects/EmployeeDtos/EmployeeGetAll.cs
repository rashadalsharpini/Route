using System.ComponentModel.DataAnnotations;
using Data.Models.Employee;
using Data.Models.Shared.Enums;

namespace BusinessLogic.DataTransferObjects.EmployeeDtos;

public class EmployeeGetAll
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }
    [DataType(DataType.Currency)]
    public double Salary { get; set; }
    public string Email { get; set; }
    public string EmpGender { get; set; }
    [Display(Name = "Employee Type")]
    public string EmpType { get; set; }
    public int? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
}
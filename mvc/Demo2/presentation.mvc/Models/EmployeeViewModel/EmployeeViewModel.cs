using Data.Models.Employee;
using Data.Models.Shared.Enums;

namespace presentation.mvc.Models.EmployeeViewModel;
using System.ComponentModel.DataAnnotations;

public class EmployeeViewModel
{
    [Required(ErrorMessage = "Employee name is required")]
    [MaxLength(50, ErrorMessage = "Employee name cannot be more than 50 characters")]
    [MinLength(5, ErrorMessage = "Employee name cannot be less than 5 characters")]
    public string Name { get; set; } = null!;
    [Range(22, 35)]
    public int Age { get; set; }
    [RegularExpression("^[1-9]{1,3} [a-zA-Z]{5,10} [a-zA-Z]{5,10}$", 
        ErrorMessage = "Address must be like 123-street-city-country")]
    public string? Address { get; set; } = null!;
    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }
    public double Salary { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = null!;
    [Display(Name = "Phone number")]
    [Required(ErrorMessage = "Phone number is required")]
    [Phone]
    public string Phone { get; set; } = null!;
    [Display(Name = "Hire Date")]
    public DateOnly HireDate { get; set; }
    public Gender Gender { get; set; }
    public EmployeeType Type { get; set; }
    public int CreatedBy { get; set; }
    public int LastModifiedBy { get; set; }
    [Display(Name = "Department")]
    public int? DepartmentId { get; set; }
    public IFormFile? Image { get; set; }
}
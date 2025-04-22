using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.DataTransferObjects.DepartmentDtos;

public class CreatedDepartmentDto
{
    [Required(ErrorMessage = "name is required!!!")]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    [Required(ErrorMessage = "code is required!!!")]
    public string Code { get; set; } = null!;
    public DateOnly CreatedOn { get; set; }
}
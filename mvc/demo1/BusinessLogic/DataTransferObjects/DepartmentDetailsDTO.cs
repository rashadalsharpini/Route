using DataAccess.models;

namespace BusinessLogic.DataTransferObjects;

public class DepartmentDetailsDTO
{
    // constructor - based mapping
    // public DepartmentDetailsDTO(Department department)
    // {
    //     DepartmentName = department.DepartmentName;
    //     Code = department.Code;
    //     Description = department.Description;
    //     createdOn = DateOnly.FromDateTime(department.createdOn);
    // }
    public string DepartmentName { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public int id { get; set; } //PK
    public int createdBy { get; set; } // user id
    public DateOnly createdOn { get; set; }
    public int lastModifiedBy { get; set; } //user id
    public DateOnly? lastModifiedOn { get; set; }
    public bool isDeleted { get; set; } // soft delete 
}
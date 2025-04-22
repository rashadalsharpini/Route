namespace BusinessLogic.DataTransferObjects.DepartmentDtos;

public class DepartmentDetailsDto
{
    public int DeptId { get; set; } //PK
    public int CreatedBy { get; set; } // user id
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public int LastModifiedBy { get; set; } //user id
    public DateTime? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; } // soft delete 
    public string DepartmentName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }

}
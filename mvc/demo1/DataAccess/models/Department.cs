namespace DataAccess.models;

public class Department : BaseEntity
{
    public string DepartmentName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
}
namespace BusinessLogic.DataTransferObjects.DepartmentDtos;

public class UpdateDepartmenDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Code { get; set; } = null!;
    public DateOnly CreatedOn { get; set; }
}
namespace BusinessLogic.DataTransferObjects;

public class DepartmentDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly CreatedOn { get; set; }
}
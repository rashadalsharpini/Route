namespace BusinessLogic.DataTransferObjects;

public class DepartmentDTO
{
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string code { get; set; } = string.Empty;
    public DateOnly dateCreated { get; set; } 
}
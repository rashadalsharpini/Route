namespace BusinessLogic.DataTransferObjects;

public class UpdateDepartmentDto
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string code { get; set; } = string.Empty;
    public DateOnly createdDate { get; set; }
    public string description { get; set; } = string.Empty;
}
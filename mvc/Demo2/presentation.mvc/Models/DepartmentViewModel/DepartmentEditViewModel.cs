namespace presentation.mvc.Models.DepartmentViewModel;

public class DepartmentEditViewModel
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string? Description { get; set; }
    public DateOnly CreatedOn  { get; set; }
}
using BusinessLogic.DataTransferObjects;

namespace BusinessLogic.Services;

public interface IDepartmentService
{
    public IEnumerable<DepartmentDTO> getAllDepartments();
    public DepartmentDetailsDTO? Getdepartmentbyid(int departmentId);
    public int addDepartment(createdDepartmentDTO department);
    public int updatedepartment(UpdateDepartmentDto department);
    public bool DeleteDepartment(int departmentId);
    
}
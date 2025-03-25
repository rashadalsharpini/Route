using BusinessLogic.DataTransferObjects;
using BusinessLogic.Factories;
using DataAccess.Data.contexts;
using DataAccess.models;
using DataAccess.Repos;

namespace BusinessLogic.Services;

public class DepartmentService(IDepartmentRepo _departmentRepo) : IDepartmentService
{
    
    // get all departments
    public IEnumerable<DepartmentDTO> getAllDepartments()
    {
        var departments = _departmentRepo.GetAll();
        return departments.Select(d => d.toDTO());
    }
    // get department by id
    public DepartmentDetailsDTO? Getdepartmentbyid(int departmentId)
    {
        var department = _departmentRepo.GetDepartmentById(departmentId);
        return department is null ? null : department.toDetailsDTO();
    }
    // create new department
    public int addDepartment(createdDepartmentDTO department)=> 
        _departmentRepo.Add(department.toEntity());
    // update department
    public int updatedepartment(UpdateDepartmentDto department)=> 
        _departmentRepo.Update(department.ToEntity());
    // delete department
    public bool DeleteDepartment(int departmentId)
    {
        var dept = _departmentRepo.GetDepartmentById(departmentId);
        if (dept is null) return false;
        return _departmentRepo.Remove(dept) > 0;
    }
}


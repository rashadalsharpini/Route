using BusinessLogic.DataTransferObjects;
using BusinessLogic.Factories;
using BusinessLogic.Interfaces;
using Repos.Interfaces;

namespace BusinessLogic.Service;

public class DepartmentService(IDepartmentRepo _departmentRepo) : IDepartmentService
{
    public DepartmentDetailsDto GetById(int? id)
    {
        if (id == null) return null;
        var d = _departmentRepo.Getbyid(id.Value);
        return d is null ? null : d.ToDetailsDto();
    }

    public IEnumerable<DepartmentDto> GetAll(bool tracking = false)
    {
        return _departmentRepo.Getall().Select(d =>d.ToDto());
    }

    public int Add(CreatedDepartmentDto entity)
    {
        var department = entity.ToEntity();
        bool exists = _departmentRepo.ExistByCode(department.Code);
        if(exists)
            throw new Exception($"Department Code {department.Code} already exists");
        return _departmentRepo.Add(department);
    }

    public int Update(UpdateDepartmenDto entity)
    {
        return _departmentRepo.Update(entity.ToEntity());
    }

    public bool Delete(int id)
    {
        // var department = _departmentRepo.Getbyid(id);
        // if (department is null) return false;
        // int res = _departmentRepo.Delete(department);
        // return res > 0;
        var department = _departmentRepo.Getbyid(id);
        if (department == null) return false;
        department.IsDeleted = true;
        return _departmentRepo.Update(department) > 0;
    }
}
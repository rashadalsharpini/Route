using BusinessLogic.DataTransferObjects;
using BusinessLogic.Factories;
using BusinessLogic.Interfaces;
using Repos.Interfaces;

namespace BusinessLogic.Service;

public class DepartmentService(IUnitOfWork uow) : IDepartmentService
{
    public DepartmentDetailsDto GetById(int? id)
    {
        if (id == null) return null;
        var d = uow.DepartmentRepo.Getbyid(id.Value);
        return d is null ? null : d.ToDetailsDto();
    }

    public IEnumerable<DepartmentDto> GetAll(bool tracking = false)
    {
        return uow.DepartmentRepo.Getall().Select(d =>d.ToDto());
    }

    public int Add(CreatedDepartmentDto entity)
    {
        var department = entity.ToEntity();
        bool exists = uow.DepartmentRepo.ExistByCode(department.Code);
        if(exists)
            throw new Exception($"Department Code {department.Code} already exists");
        uow.DepartmentRepo.Add(department);
        return uow.Save();
    }

    public int Update(UpdateDepartmenDto entity)
    {
        uow.DepartmentRepo.Update(entity.ToEntity());
        return uow.Save();
    }

    public bool Delete(int id)
    {
        // var department = _departmentRepo.Getbyid(id);
        // if (department is null) return false;
        // int res = _departmentRepo.Delete(department);
        // return res > 0;
        var department = uow.DepartmentRepo.Getbyid(id);
        if (department == null) return false;
        department.IsDeleted = true;
        uow.DepartmentRepo.Update(department);
        return uow.Save() > 0;
    }
}
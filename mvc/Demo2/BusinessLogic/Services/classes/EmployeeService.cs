using AutoMapper;
using BusinessLogic.DataTransferObjects.EmployeeDtos;
using BusinessLogic.Services.AttachementService;
using BusinessLogic.Services.Interfaces;
using Data.Models.Employee;
using Repos.Interfaces;

namespace BusinessLogic.Services.classes;

public class EmployeeService(IUnitOfWork uow, IMapper mapper,
    IAttachementService attachementService) :  IEmployeeService
{
    public EmployeeGetById GetById(int? id)
    {
        if (id == null) return null;
        // var e = _employeeRepo.Getbyid(id.Value).ToGI();
        var e = mapper.Map<Employee, EmployeeGetById>(uow.EmployeeRepo.Getbyid(id.Value));
        return e is null ? null : e;
    }

    public IEnumerable<EmployeeGetAll> GetAll(string? employeeSearchName, bool tracking = false)
    {
        IEnumerable<Employee> employees;
        if (string.IsNullOrWhiteSpace(employeeSearchName))
            employees = uow.EmployeeRepo.Getall();
        else employees = uow.EmployeeRepo.Getall(e => e.Name.ToLower().Contains(employeeSearchName.ToLower()));
        return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeGetAll>>(employees);
    }

    public int Add(AddEmployee entity)
    {
        var emp = mapper.Map<AddEmployee, Employee>(entity);
        if (entity.Image is not null)
        {
            emp.ImageName = attachementService.Upload(entity.Image, "Images");
        }
        uow.EmployeeRepo.Add(emp); // done locally didn't affect db yet
        // do your logic
        return uow.Save();
    }
    
    public int Update(UpdateEmployee entity)
    {
        var emp = mapper.Map<UpdateEmployee, Employee>(entity);
        if (entity.Image is not null)
        {
            emp.ImageName = attachementService.Upload(entity.Image, "Images");
        }
        uow.EmployeeRepo.Update(emp);
        return uow.Save();
    }

    public bool Delete(int id)
    { // soft delete
        var e = uow.EmployeeRepo.Getbyid(id);
        if (e is null) return false;
        e.IsDeleted = true;
        uow.EmployeeRepo.Update(e);
        return uow.Save() > 0;
    }

    public Employee GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Employee> GetByAddress(string address)
    {
        throw new NotImplementedException();
    }
}

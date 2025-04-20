using AutoMapper;
using BusinessLogic.DataTransferObjects.EmployeeDtos;
using BusinessLogic.Factories;
using BusinessLogic.Interfaces;
using Data.Models.Employee;
using Repos.Interfaces;

namespace BusinessLogic.Service;

public class EmployeeService(IUnitOfWork uow, IMapper mapper) :  IEmployeeService
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
        IEnumerable<Employee> employess;
        if (string.IsNullOrWhiteSpace(employeeSearchName))
            employess = uow.EmployeeRepo.Getall();
        else employess = uow.EmployeeRepo.Getall(e => e.Name.ToLower().Contains(employeeSearchName.ToLower()));
        return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeGetAll>>(employess);
    }

    public int Add(AddEmployee entity)
    {
        uow.EmployeeRepo.Add(mapper.Map<AddEmployee, Employee>(entity)); // done local didn't effect db yet
        // do your logic
        return uow.Save();
    }
    
    public int Update(UpdateEmployee entity)
    {
        uow.EmployeeRepo.Update(mapper.Map<UpdateEmployee, Employee>(entity));
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
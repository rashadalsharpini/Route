using AutoMapper;
using BusinessLogic.DataTransferObjects.EmployeeDtos;
using BusinessLogic.Factories;
using BusinessLogic.Interfaces;
using Data.Models.Employee;
using Repos.Interfaces;

namespace BusinessLogic.Service;

public class EmployeeService(IEmployeeRepo _employeeRepo, IMapper mapper) :  IEmployeeService
{
    public EmployeeGetById GetById(int? id)
    {
        if (id == null) return null;
        // var e = _employeeRepo.Getbyid(id.Value).ToGI();
        var e = mapper.Map<Employee, EmployeeGetById>(_employeeRepo.Getbyid(id.Value));
        return e is null ? null : e;
    }

    public IEnumerable<EmployeeGetAll> GetAll(bool tracking = false)
    {
        // return _employeeRepo.Getall().Select(e => e.ToGA());
        // src=>dest
        //emp=>empgetall
        return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeGetAll>>(_employeeRepo.Getall());
    }

    public int Add(AddEmployee entity)
    {
        return _employeeRepo.Add(mapper.Map<AddEmployee, Employee>(entity));
    }

    public int Update(UpdateEmployee entity)
    {
        return _employeeRepo.Update(mapper.Map<UpdateEmployee, Employee>(entity));
    }

    public bool Delete(int id)
    { // soft delete
        var e = _employeeRepo.Getbyid(id);
        if (e is null) return false;
        e.IsDeleted = true;
        return _employeeRepo.Update(e) > 0;
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
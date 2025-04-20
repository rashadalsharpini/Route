using BusinessLogic.DataTransferObjects.EmployeeDtos;
using Data.Models.Employee;

namespace BusinessLogic.Interfaces;

public interface IEmployeeService
{
    EmployeeGetById GetById(int? id);
    IEnumerable<EmployeeGetAll> GetAll(string? employeeSearchName, bool tracking = false);
    int Add(AddEmployee entity);
    int Update(UpdateEmployee entity);
    bool Delete(int id);
    Employee GetByName(string name);
    IEnumerable<Employee> GetByAddress(string address);
}
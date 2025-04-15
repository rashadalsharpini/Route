using Data.Models;
using Data.Models.Employee;

namespace Repos.Interfaces;

public interface IEmployeeRepo : IGenericRepo<Employee>
{
    Employee? GetEmployeeByName(string name);
    IEnumerable<Employee> GetEmployeesByAddress(string address);
}
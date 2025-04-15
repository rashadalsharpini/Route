using Data.Contexts;
using Data.Models;
using Data.Models.Employee;
using Microsoft.EntityFrameworkCore;
using Repos.Interfaces;

namespace Repos.Repos;

public class EmployeeRepo(AppDbContext db) : GenericRepo<Employee>(db), IEmployeeRepo
{
    public Employee? GetEmployeeByName(string name)
    {
        var lst = db.Set<Employee>().ToList();
        return lst.FirstOrDefault(e=>e.Name==name);
    }

    public IEnumerable<Employee> GetEmployeesByAddress(string address)
    {
        var lst = db.Set<Employee>().ToList();
        return lst.Where(e=>e.Address==address);
    }
    
}
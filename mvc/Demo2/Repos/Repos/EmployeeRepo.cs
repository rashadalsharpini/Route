using Data.Contexts;
using Data.Models;
using Data.Models.Employee;
using Microsoft.EntityFrameworkCore;
using Repos.Interfaces;

namespace Repos.Repos;

public class EmployeeRepo(AppDbContext db) : GenericRepo<Employee>(db), IEmployeeRepo
{
    private readonly AppDbContext _db = db;

    public Employee? GetEmployeeByName(string name)
    {
        var lst = _db.Set<Employee>().ToList();
        return lst.FirstOrDefault(e=>e.Name==name);
    }

    public IEnumerable<Employee> GetEmployeesByAddress(string address)
    {
        var lst = _db.Set<Employee>().ToList();
        return lst.Where(e=>e.Address==address);
    }
    
}
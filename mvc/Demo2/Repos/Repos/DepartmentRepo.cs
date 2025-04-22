using Data.Contexts;
using Data.Models;
using Data.Models.Department;
using Microsoft.EntityFrameworkCore;
using Repos.Interfaces;

namespace Repos.Repos;

public class DepartmentRepo(AppDbContext db) : GenericRepo<Department>(db), IDepartmentRepo
{
    private readonly AppDbContext _db = db;

    public bool ExistByCode(string code)
    {
        return _db.Departments.Any(d => d.Code == code && !d.IsDeleted);
    }
}
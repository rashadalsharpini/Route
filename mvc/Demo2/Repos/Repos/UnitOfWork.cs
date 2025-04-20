using Data.Contexts;
using Repos.Interfaces;

namespace Repos.Repos;

public class UnitOfWork : IUnitOfWork
{
    private readonly Lazy<IDepartmentRepo> _departmentRepo;
    private readonly Lazy<IEmployeeRepo> _employeeRepo;
    private readonly AppDbContext _db;
    public UnitOfWork(AppDbContext db)
    {
        _db = db;
        _departmentRepo = new Lazy<IDepartmentRepo>(()=>new DepartmentRepo(db));
        _employeeRepo = new Lazy<IEmployeeRepo>(()=>new EmployeeRepo(db));
    }

    public IEmployeeRepo EmployeeRepo => _employeeRepo.Value;
    public IDepartmentRepo DepartmentRepo => _departmentRepo.Value;
    public int Save() => _db.SaveChanges();
}
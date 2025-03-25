using DataAccess.Data.contexts;

namespace DataAccess.Repos;

public class DepartmentRepo(applicationDbContext dbcontext) : IDepartmentRepo
{

    private readonly applicationDbContext _dbcontext = dbcontext;
    
    // CRUD  operations
    // get by id
    public Department? GetDepartmentById(int id) => _dbcontext.Departments.Find(id);
    // get all
    public IEnumerable<Department> GetAll(bool trackChanges = false)
    {
        if (trackChanges)
            return _dbcontext.Departments.ToList();
        else
            return _dbcontext.Departments.AsNoTracking().ToList();
    }
    // update
    public int Update(Department department)
    {
        _dbcontext.Departments.Update(department);
        return _dbcontext.SaveChanges();
    }
    // delete
    public int Remove(Department department)
    {
        _dbcontext.Departments.Remove(department);
        return _dbcontext.SaveChanges();
    }
    // insert
    public int Add(Department department)
    {
        _dbcontext.Departments.Add(department);
        return _dbcontext.SaveChanges();
    }
}
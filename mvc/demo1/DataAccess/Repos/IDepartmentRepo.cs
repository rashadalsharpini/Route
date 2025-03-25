namespace DataAccess.Repos;

public interface IDepartmentRepo
{
    // get by id
    public Department? GetDepartmentById(int id);
    // get all
    public IEnumerable<Department> GetAll(bool trackChanges = false);
    // update
    public int Update(Department department);
    // delete
    public int Remove(Department department);
    // insert
    public int Add(Department department);
}
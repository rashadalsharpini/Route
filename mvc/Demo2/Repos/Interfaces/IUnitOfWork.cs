namespace Repos.Interfaces;

public interface IUnitOfWork
{
    public  IEmployeeRepo EmployeeRepo { get; }
    public  IDepartmentRepo DepartmentRepo { get; }
    public int Save();
}
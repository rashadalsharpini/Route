using Data.Models;
using Data.Models.Department;

namespace Repos.Interfaces;

public interface IDepartmentRepo : IGenericRepo<Department>
{
    bool ExistByCode(string departmentCode);
}
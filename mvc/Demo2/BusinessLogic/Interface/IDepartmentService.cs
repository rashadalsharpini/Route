using BusinessLogic.DataTransferObjects;

namespace BusinessLogic.Interfaces;

public interface IDepartmentService
{
    DepartmentDetailsDto GetById(int? id);
    IEnumerable<DepartmentDto> GetAll(bool tracking = false);
    int Add(CreatedDepartmentDto entity);
    int Update(UpdateDepartmenDto entity);
    bool Delete(int id);
}
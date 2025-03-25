using BusinessLogic.DataTransferObjects;
using DataAccess.models;

namespace BusinessLogic.Factories;
// extension methods
public static class DepartmentFactory
{
    public static DepartmentDTO toDTO(this Department d)
    {
        return new DepartmentDTO()
        {
            DepartmentId = d.id,
            code = d.Code,
            Description = d.Description,
            Name = d.DepartmentName,
            dateCreated = DateOnly.FromDateTime(d.createdOn)
        };
    }

    public static DepartmentDetailsDTO toDetailsDTO(this Department d)
    {
        return new DepartmentDetailsDTO()
        {

            DepartmentName = d.DepartmentName,
            Code = d.Code,
            Description = d.Description,
            createdOn = DateOnly.FromDateTime(d.createdOn),
        };
    }

    public static Department toEntity(this createdDepartmentDTO dto)
    {
        return new Department()
        {
            DepartmentName = dto.name,
            Code = dto.code,
            Description = dto.description,
            createdOn = dto.createdDate.ToDateTime(new TimeOnly())
        };
    }

    public static Department ToEntity(this UpdateDepartmentDto dto)
    {
        return new Department()
        {
            id = dto.id,
            DepartmentName = dto.name,
            Code = dto.code,
            Description = dto.description,
            createdOn = dto.createdDate.ToDateTime(new TimeOnly())
        };
    }
}
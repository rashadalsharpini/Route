using BusinessLogic.DataTransferObjects;
using BusinessLogic.DataTransferObjects.DepartmentDtos;
using Data.Models;
using Data.Models.Department;

namespace BusinessLogic.Factories;

public static class DepartmentFactory
{
    public static DepartmentDto ToDto(this Department d)
    {
        return new DepartmentDto()
        {
            Id = d.Id,
            Code = d.Code,
            Name = d.DepartmentName,
            Description = d.Description,
            CreatedOn = DateOnly.FromDateTime(d.CreatedOn)
        };
    }

    public static DepartmentDetailsDto ToDetailsDto(this Department d)
    {
        return new DepartmentDetailsDto()
        {
            DeptId = d.Id,
            Code = d.Code,
            DepartmentName = d.DepartmentName,
            Description = d.Description,
            CreatedBy = d.CreatedBy,
            CreatedOn = d.CreatedOn,
            IsDeleted = d.IsDeleted,
            LastModifiedBy = d.LastModifiedBy,
            LastModifiedOn = d.LastModifiedOn,
        };
    }

    public static Department ToEntity(this CreatedDepartmentDto d)
    {
        return new Department()
        {
            Code = d.Code,
            DepartmentName = d.Name,
            Description =  d.Description,
            CreatedOn = d.CreatedOn.ToDateTime(new TimeOnly())
        };
    }

    public static Department ToEntity(this UpdateDepartmenDto d)
    {
        return new Department()
        {
            Id = d.Id,
            Code = d.Code,
            DepartmentName = d.Name,
            Description = d.Description,
            CreatedOn = d.CreatedOn.ToDateTime(new TimeOnly())
        };
    }
}
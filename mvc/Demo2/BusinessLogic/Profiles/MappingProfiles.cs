using AutoMapper;
using BusinessLogic.DataTransferObjects.EmployeeDtos;
using Data.Models.Employee;

namespace BusinessLogic.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Employee, EmployeeGetAll>()
            .ForMember(dest=>dest.EmpGender,
                opt=>opt.MapFrom(src=>src.Gender))
            .ForMember(dest=>dest.EmpType,
                opt=>opt.MapFrom(src=>src.Type))
            .ForMember(dest=>dest.DepartmentName,
                opt=>opt.MapFrom(src=>src.Department.DepartmentName!=null?src.Department.DepartmentName:null));
        CreateMap<Employee, EmployeeGetById>()
            .ForMember(dest => dest.HireDate,
                opt => opt.MapFrom(src => DateOnly.FromDateTime(src.HireDate)))
            .ForMember(dest=>dest.DepartmentName,
            opt=>opt.MapFrom(src=>src.Department.DepartmentName!=null?src.Department.DepartmentName:null));
        CreateMap<AddEmployee, Employee>()
            .ForMember(dest=>dest.HireDate,
                opt=>opt.MapFrom(src=>src.HireDate.ToDateTime(new TimeOnly())));
        CreateMap<UpdateEmployee, Employee>().ForMember(dest=>dest.HireDate,
            opt=>opt.MapFrom(src=>src.HireDate.ToDateTime(new TimeOnly())));
    }
}
using BusinessLogic.DataTransferObjects.EmployeeDtos;
using Data.Models.Employee;

namespace BusinessLogic.Factories;

public static class EmployeeFactory
{
    public static EmployeeGetAll ToGA(this Employee e)
    {
        return new EmployeeGetAll()
        {
            Id = e.Id,
            Name = e.Name,
            Age = e.Age,
            IsActive = e.IsActive,
            Salary = e.Salary,
            Email = e.Email,
            EmpGender = e.Gender.ToString(),
            EmpType = e.Type.ToString()
        };
    }

    public static EmployeeGetById ToGI(this Employee? emp)
    {
        return new EmployeeGetById()
        {
            Id = emp.Id,
            Name = emp.Name,
            Age = emp.Age,
            IsActive = emp.IsActive,
            Salary = emp.Salary,
            Email = emp.Email,
            Gender = emp.Gender.ToString(),
            Type = emp.Type.ToString(),
            HireDate = DateOnly.FromDateTime(emp.HireDate),
            Phone = emp.Phone,
            Address = emp.Address,
        };
    }

    public static Employee ToEntity(this AddEmployee emp)
    {
        return new Employee()
        {
            Name = emp.Name,
            Age = emp.Age,
            IsActive = emp.IsActive,
            Salary = emp.Salary,
            Email = emp.Email,
            Gender = emp.Gender,
            Type = emp.Type,
            HireDate = emp.HireDate.ToDateTime(new TimeOnly()),
            Phone = emp.Phone,
            Address = emp.Address,
            CreatedBy = emp.CreatedBy,
            LastModifiedBy = emp.LastModifiedBy,
        };
    }

    public static Employee ToEntity(this UpdateEmployee e)
    {
        return new Employee()
        {
            Id = e.Id,
            Name = e.Name,
            Age = e.Age,
            IsActive = e.IsActive,
            Salary = e.Salary,
            Email = e.Email,
            Gender = e.Gender,
            Type = e.Type,
            HireDate = e.HireDate.ToDateTime(new TimeOnly()),
            Phone = e.Phone,
            Address = e.Address,
            CreatedBy = e.CreatedBy,
            LastModifiedBy = e.LastModifiedBy,
        };
    }
}
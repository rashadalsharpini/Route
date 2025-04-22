using BusinessLogic.DataTransferObjects.EmployeeDtos;
using BusinessLogic.Services.Interfaces;
using Data.Models.Employee;
using Data.Models.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using presentation.mvc.Models.EmployeeViewModel;

namespace presentation.mvc.Controllers;

public class EmployeeController(IEmployeeService employeeService,ILogger<DepartmentController> logger
    ,IWebHostEnvironment environment) : Controller
{
    [HttpGet]
    public IActionResult Index(string? employeeSearchName)
    {
        return View(employeeService.GetAll(employeeSearchName));
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    } 

    [HttpPost]
    public IActionResult Create(EmployeeViewModel employee)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var employeeDto = new AddEmployee()
                {
                    Address = employee.Address,
                    Age = employee.Age,
                    Email = employee.Email,
                    Gender = employee.Gender,
                    HireDate = employee.HireDate,
                    IsActive = employee.IsActive,
                    Name = employee.Name,
                    Phone = employee.Phone,
                    Salary = employee.Salary,
                    Type = employee.Type,
                    DepartmentId = employee.DepartmentId,
                    Image = employee.Image,
                };
                int res = employeeService.Add(employeeDto);
                if (res > 0)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "department Can't be created");
            }
            catch (Exception ex)
            {
                if(environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty,ex.Message);
                    return View(employee);
                }
                logger.LogError(ex.Message);
            }
        }

        return View(employee);
    }
    
    public IActionResult Details(int? id)
    {
        if (!id.HasValue) return BadRequest();
        var employee = employeeService.GetById(id.Value);
        if (employee is null) return NotFound();
        return View(employee);
        
    }

    [HttpGet]
    public IActionResult Update(int? id)
    {
        if(!id.HasValue) return BadRequest();
        var employee = employeeService.GetById(id.Value);
        if (employee is null) return NotFound();
        var empvm = new EmployeeViewModel() {
            // Id = employee.Id,
            Name = employee.Name,
            Phone = employee.Phone,
            HireDate = employee.HireDate,
            Gender = Enum.Parse<Gender>(employee.Gender),
            Type = Enum.Parse<EmployeeType>(employee.Type),
            Age =  employee.Age,
            Salary = employee.Salary,
            Address = employee.Address,
            IsActive = employee.IsActive,
            Email = employee.Email,
            DepartmentId = employee.DepartmentId,
        };
        return View(empvm);
    }
    [HttpPost]
    public IActionResult Update([FromRoute]int? id, EmployeeViewModel empvm)
    {
        if(!id.HasValue) return BadRequest();
        if (!ModelState.IsValid) return View(empvm);
        try
        {
            var empDto = new UpdateEmployee()
            {
                Id = id.Value,
                Name = empvm.Name,
                Phone = empvm.Phone,
                HireDate = empvm.HireDate,
                Gender = empvm.Gender,
                Type = empvm.Type,
                Age = empvm.Age,
                Salary = empvm.Salary,
                Address = empvm.Address,
                IsActive = empvm.IsActive,
                Email = empvm.Email,
                DepartmentId = empvm.DepartmentId,
            };
            var res = employeeService.Update(empDto);
            if(res > 0) return RedirectToAction(nameof(Index));
            ModelState.AddModelError(string.Empty, "not updated");
            return View(empvm);
        }
        catch (Exception ex)
        {
            if(environment.IsDevelopment())
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return View(empvm);
            }
            logger.LogError(ex.Message);
            // return View("Error", ex);
        }
        return View(empvm);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        if (id == 0) return BadRequest();
        try
        {
            bool deleted = employeeService.Delete(id);
            if (deleted) return RedirectToAction(nameof(Index));
            ModelState.AddModelError(string.Empty, "employee is not deleted");
            return RedirectToAction(nameof(Delete), new { id });
        }
        catch (Exception ex)
        {
            if (environment.IsDevelopment())
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            logger.LogError(ex.Message);
            return View("NotFound");
        }
    }
}
using BusinessLogic.DataTransferObjects.EmployeeDtos;
using BusinessLogic.Interfaces;
using Data.Models.Employee;
using Data.Models.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using presentation.mvc.Controllers;

public class EmployeeController(IEmployeeService employeeService,ILogger<DepartmentController> logger
    ,IWebHostEnvironment environment) : Controller
{
    [HttpGet]
    public IActionResult Index() => View(employeeService.GetAll());

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(AddEmployee employee)
    {
        if (ModelState.IsValid)
        {
            try
            {
                int res = employeeService.Add(employee);
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
        var empDto = new UpdateEmployee() {
            Id = employee.Id,
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
            
        };
        return View(empDto);
    }
    [HttpPost]
    public IActionResult Update([FromRoute]int? id, UpdateEmployee empDto)
    {
        if(!id.HasValue || id != empDto.Id) return BadRequest();
        if (!ModelState.IsValid) return View(empDto);
        try
        {
            var res = employeeService.Update(empDto);
            if(res > 0) return RedirectToAction(nameof(Index));
            ModelState.AddModelError(string.Empty, "not updated");
            return View(empDto);
        }
        catch (Exception ex)
        {
            if(environment.IsDevelopment())
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return View(empDto);
            }
            logger.LogError(ex.Message);
            // return View("Error", ex);
        }
        return View(empDto);
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
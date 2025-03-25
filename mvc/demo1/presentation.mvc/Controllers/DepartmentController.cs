using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace presentation.mvc.Controllers;

public class DepartmentController(IDepartmentService departmentService) : Controller
{
    // GET
    public IActionResult Index()
    {
        var departments = departmentService.getAllDepartments();
        return View(departments);
    }
}
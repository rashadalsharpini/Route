using BusinessLogic.DataTransferObjects;
using BusinessLogic.DataTransferObjects.DepartmentDtos;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using presentation.mvc.Models.DepartmentViewModel;

namespace presentation.mvc.Controllers;

public class DepartmentController(IDepartmentService departmentService
    ,ILogger<DepartmentController> logger
    ,IWebHostEnvironment environment) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        // ViewData["Message"] = "from view data";
        // ViewBag.message = "from view bag";
        return View(departmentService.GetAll());
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(DepartmentViewModel department)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var departmentDto = new CreatedDepartmentDto()
                {
                    Code = department.Code,
                    Description = department.Description,
                    Name = department.Name,
                    CreatedOn = department.CreatedOn
                };
                int res = departmentService.Add(departmentDto);
                string message = res > 0 ? "department is created" : "department can't be created";
                TempData["message"] = message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if(environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty,ex.Message);
                    return View(department);
                }
                logger.LogError(ex.Message);
            }
        }

        return View(department);
    }
    public IActionResult Details(int? id)
    {
        if (!id.HasValue) return BadRequest();
        var department = departmentService.GetById(id.Value);
        if (department is null) return View("NotFound");
        return View(department);
        
    }

    [HttpGet]
    public IActionResult Update(int? id)
    {
        if (!id.HasValue) return BadRequest();
        var department = departmentService.GetById(id.Value);
        if (department is null) return View("NotFound");
        var dvm = new DepartmentViewModel()
        {
            Code = department.Code,
            Description = department.Description,
            Name = department.DepartmentName,
            CreatedOn = DateOnly.FromDateTime(department.CreatedOn)
        };
        return View(dvm);
        
    }

    [HttpPost]
    public IActionResult Update([FromRoute]int id, DepartmentViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var upddept = new UpdateDepartmenDto()
                {
                    Id = id,
                    Code = viewModel.Code,
                    Description = viewModel.Description,
                    Name = viewModel.Name,
                    CreatedOn = viewModel.CreatedOn
                };
                int res = departmentService.Update(upddept);
                if (res > 0) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "department is not updated");
                }
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
        return View(viewModel);
        
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        if (id == 0) return BadRequest();
        try
        {
            bool deleted = departmentService.Delete(id);
            if (deleted) return RedirectToAction(nameof(Index));
            ModelState.AddModelError(string.Empty, "department is not deleted");
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
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class MoviesController : Controller
{
    public string Index()
    {
        return "welcome MTF from movies index";
    }
    
    [HttpGet]
    public IActionResult getMovies(int? id, string? name)
    {
        if (id == null)
            return Content("id is null");
        if (id == 0)
            return BadRequest();
        if (id < 10)
            return NotFound();
        if(name is null)
            return Content($"movies {id}", "text/plain");
        return Content($"movies {id}, {name}", "text/plain");
    }

    public IActionResult testRedirectionAction()
    {
        return RedirectToAction("getMovies", "Movies", new { id = 10, name = "test" });
    }
}
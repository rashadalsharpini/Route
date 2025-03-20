using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult SignIn()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
}
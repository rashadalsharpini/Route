using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiBaseController : ControllerBase
{
    protected string GetEmailFromToken()=>
        User.FindFirstValue(ClaimTypes.Email)!;
}
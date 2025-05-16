using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTOs.IdentityDtos;

namespace Presentation.Controllers;

public class AuthenticationController(IServiceManager serviceManager) : ApiBaseController
{
    [HttpPost("Login")] //POST BaseUrl/api/authentication/login
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto dto)
        => Ok(await serviceManager.AuthenticationService.LoginAsync(dto));

    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto dto)
        => Ok(await serviceManager.AuthenticationService.RegisterAsync(dto));
}
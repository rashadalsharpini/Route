using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTOs.IdentityDtos;

namespace Presentation.Controllers;

public class AuthenticationController(IServiceManager serviceManager) : ApiBaseController
{
    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto dto)
        => Ok(await serviceManager.AuthenticationService.LoginAsync(dto));

    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto dto)
        => Ok(await serviceManager.AuthenticationService.RegisterAsync(dto));

    [HttpGet("checkEmail")]
    public async Task<ActionResult<bool>> CheckEmail(string email)
        => Ok(await serviceManager.AuthenticationService.CheckEmailAsync(email));

    [Authorize]
    [HttpGet("CurrentUser")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        return Ok(await serviceManager.AuthenticationService.GetCurrentUserAsync(email!));
    }

    [Authorize]
    [HttpGet("Address")]
    public async Task<ActionResult<AddressDto>> GetCurrentUserAddress()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        return Ok(await serviceManager.AuthenticationService.GetCurrentUserAddressAsync(email!));
    }

    [Authorize]
    [HttpPut("Address")]
    public async Task<ActionResult<AddressDto>> UpdateCurrentUserAddress(AddressDto dto)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        return Ok(await serviceManager.AuthenticationService.UpdateCurrentUserAddressAsync(email!, dto));
    }
}
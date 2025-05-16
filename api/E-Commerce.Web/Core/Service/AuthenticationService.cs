using Domain.Execptions;
using Domain.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using ServiceAbstraction;
using Shared.DTOs.IdentityDtos;

namespace Service;

public class AuthenticationService(UserManager<AppUser> userManager) : IAuthenticationService
{
    public async Task<UserDto> LoginAsync(LoginDto dto)
    {
        var User = await userManager.FindByEmailAsync(dto.Email) ?? throw new UserNotFoundException(dto.Email);
        var IsPassword = await userManager.CheckPasswordAsync(User, dto.Password);
        if (IsPassword)
            return new UserDto()
            {
                DisplayName = User.DisplayName,
                Email = User.Email,
                Token = GenerateToken(User),
            };
        throw new UnauthorizedException();
    }

    public async Task<UserDto> RegisterAsync(RegisterDto dto)
    {
        var User = new AppUser()
        {
            DisplayName = dto.DisplayName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            UserName = dto.UserName,
        };
        var res = await userManager.CreateAsync(User, dto.Password);
        if (res.Succeeded)
            return new UserDto()
            {
                DisplayName = User.DisplayName,
                Email = User.Email,
                Token = GenerateToken(User),
            };
        var errors = res.Errors.Select(e => e.Description); 
        throw new BadRequestException(errors);
    }

    private static string GenerateToken(AppUser user)
    {
        // todo
        return "some shit";
    }
}
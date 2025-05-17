using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Execptions;
using Domain.Models.IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using Shared.DTOs.IdentityDtos;

namespace Service;

public class AuthenticationService(UserManager<AppUser> userManager, IConfiguration conf) : IAuthenticationService
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
                Token = await GenerateToken(User),
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
                Token = await GenerateToken(User),
            };
        var errors = res.Errors.Select(e => e.Description);
        throw new BadRequestException(errors);
    }

    private async Task<string> GenerateToken(AppUser user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Id!),
        };
        var roles = await userManager.GetRolesAsync(user);
        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));
        var secretKey = conf.GetSection("JWTOptions")["SecretKey"];  
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token =  new JwtSecurityToken(
            issuer: conf["JWTOptions:Issuer"],
            audience: conf.GetSection("JWTOptions")["Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
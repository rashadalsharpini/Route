using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Domain.Execptions;
using Domain.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using Shared.DTOs.IdentityDtos;

namespace Service;

public class AuthenticationService(UserManager<AppUser> userManager, IConfiguration conf, IMapper map)
    : IAuthenticationService
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
                Token = await GenerateTokenAsync(User),
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
                Token = await GenerateTokenAsync(User),
            };
        var errors = res.Errors.Select(e => e.Description);
        throw new BadRequestException(errors);
    }

    public async Task<bool> CheckEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        return user is not null;
    }

    public async Task<AddressDto> GetCurrentUserAddressAsync(string email)
    {
        var user = await userManager.Users.Include(u => u.Address)
            .FirstOrDefaultAsync(u => u.Email == email) ?? throw new UserNotFoundException(email);
        if (user.Address is not null)
            return map.Map<Address, AddressDto>(user.Address);
        throw new AddressNotFoundException(email);
    }

    public async Task<AddressDto> UpdateCurrentUserAddressAsync(string email, AddressDto dto)
    {
        var user = await userManager.Users.Include(u => u.Address)
            .FirstOrDefaultAsync(u => u.Email == email) ?? throw new UserNotFoundException(email);
        if (user.Address is not null)
        {
            user.Address.FirstName = dto.FirstName;
            user.Address.LastName = dto.LastName;
            user.Address.City = dto.City;
            user.Address.Street = dto.Street;
            user.Address.Country = dto.Country;
        }
        else
            user.Address = map.Map<AddressDto, Address>(dto);

        await userManager.UpdateAsync(user);
        return map.Map<AddressDto>(user.Address);
    }

    public async Task<UserDto> GetCurrentUserAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email) ?? throw new UserNotFoundException(email);
        return new UserDto()
        {
            DisplayName = user.DisplayName,
            Email = user.Email,
            Token = await GenerateTokenAsync(user),
        };
    }

    private async Task<string> GenerateTokenAsync(AppUser user)
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
        var token = new JwtSecurityToken(
            issuer: conf["JWTOptions:Issuer"],
            audience: conf.GetSection("JWTOptions")["Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
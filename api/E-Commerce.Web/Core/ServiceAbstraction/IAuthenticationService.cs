using Shared.DTOs.IdentityDtos;

namespace ServiceAbstraction;

public interface IAuthenticationService
{
    Task<UserDto> LoginAsync(LoginDto dto);
    Task<UserDto> RegisterAsync(RegisterDto dto);
}
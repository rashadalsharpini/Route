using Shared.DTOs.IdentityDtos;

namespace ServiceAbstraction;

public interface IAuthenticationService
{
    Task<UserDto> LoginAsync(LoginDto dto);
    Task<UserDto> RegisterAsync(RegisterDto dto);
    Task<bool> CheckEmailAsync(string email);
    Task<AddressDto> GetCurrentUserAddressAsync(string email);
    Task<AddressDto> UpdateCurrentUserAddressAsync(string email, AddressDto dto);
    Task<UserDto> GetCurrentUserAsync(string email);
}
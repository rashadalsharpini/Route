using Microsoft.AspNetCore.Identity;

namespace Domain.Models.IdentityModel;

public class AppUser :IdentityUser
{
    public string DisplayName { get; set; } = null!;
    public Address? Address { get; set; }
}

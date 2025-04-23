using Microsoft.AspNetCore.Identity;

namespace Data.Models.Identity;

public class AppUser:IdentityUser
{
    public string? FirstName { get; set; } = null!;
    public string? LastName { get; set; } = null!;
}
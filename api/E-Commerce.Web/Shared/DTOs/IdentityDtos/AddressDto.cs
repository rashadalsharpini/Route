namespace Shared.DTOs.IdentityDtos;

public class AddressDto
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
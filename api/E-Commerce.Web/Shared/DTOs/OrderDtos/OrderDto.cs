using Shared.DTOs.IdentityDtos;

namespace Shared.DTOs.OrderDtos;

public class OrderDto
{
    public string BasketId { get; set; } = default!;
    public int DeliveryMethodId { get; set; }
    public AddressDto Address { get; set; } = default!;
}
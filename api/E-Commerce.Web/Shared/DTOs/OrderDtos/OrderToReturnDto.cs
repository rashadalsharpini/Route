using Shared.DTOs.IdentityDtos;

namespace Shared.DTOs.OrderDtos;

public class OrderToReturnDto
{
    public Guid Id { get; set; }
    public string UserEmail { get; set; } = default!;
    public DateTimeOffset OrderDate { get; set; }
    public AddressDto Address { get; set; } = default!;
    public String DeliveryMethod { get; set; } = default!;
    public string OrderStatus { get; set; } = default!;
    public ICollection<OrderItemDto> OrderItems { get; set; } = [];
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
}
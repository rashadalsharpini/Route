using Shared.DTOs.IdentityDtos;

namespace Shared.DTOs.OrderDtos;

public class OrderToReturnDto
{
    public Guid Id { get; set; }
    public string buyerEmail { get; set; } = default!;
    public DateTimeOffset OrderDate { get; set; }
    public AddressDto shipToAddress { get; set; } = default!;
    public String DeliveryMethod { get; set; } = default!;
    public decimal deliveryCost { get; set; }
    public string Status { get; set; } = default!;
    public ICollection<OrderItemDto> OrderItems { get; set; } = [];
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
}
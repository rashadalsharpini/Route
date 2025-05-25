namespace Domain.Models.OrderModel;

public class Order:BaseEntity<Guid>
{
    public string UserEmail { get; set; } = null!;
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public OrderAddress Address { get; set; } = default!;
    public DeliveryMethod DeliveryMethod { get; set; } = default!;
    public int DeliveryMethodId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    public decimal SubTotal { get; set; }
    public decimal Total() => SubTotal+DeliveryMethod.Price;
}
namespace Domain.Models.OrderModel;

public class Order : BaseEntity<Guid>
{
    public Order()
    {
    }

    public Order(string buyerEmail, OrderAddress shipToAddress, DeliveryMethod deliveryMethod,
        ICollection<OrderItem> orderItems, decimal subTotal, string paymentIntentId)
    {
        BuyerEmail = buyerEmail;
        ShipToAddress = shipToAddress;
        DeliveryMethod = deliveryMethod;
        Items = orderItems;
        SubTotal = subTotal;
        PaymentIntentId = paymentIntentId;
    }

    public string BuyerEmail { get; set; } = null!;
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public OrderAddress ShipToAddress { get; set; } = default!;
    public DeliveryMethod DeliveryMethod { get; set; } = default!;
    public int DeliveryMethodId { get; set; }
    public OrderStatus Status { get; set; }
    public ICollection<OrderItem> Items { get; set; } = [];
    public decimal SubTotal { get; set; }
    public decimal Total() => SubTotal + DeliveryMethod.Cost;
    public string PaymentIntentId { get; set; } = null!;
}
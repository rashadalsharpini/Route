namespace Domain.Models.BasketModel;

public class CustomerBasket
{
    public string Id { get; set; } //GUID
    public ICollection<BasktItem> Items { get; set; } = [];
    
    public string? clientSecret { get; set; }
    public string? paymentIntentId { get; set; }
    public int? deliveryMethodId { get; set; }
    public decimal shippingPrice { get; set; }
}
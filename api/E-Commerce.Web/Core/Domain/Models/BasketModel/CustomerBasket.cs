namespace Domain.Models.BasketModel;

public class CustomerBasket
{
    public string Id { get; set; } //GUID
    public ICollection<BasktItem> Items { get; set; } = [];
    
}
namespace Domain.Models.BasketModel;

public class BasktItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public string PictureUrl { get; set; } = null!;
}
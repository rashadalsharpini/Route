namespace Domain.Models.OrderModel;

public class ProductItemOrder
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
}
namespace Shared.DTOs.productDto;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public string PictureUrl { get; set; } = default!;
    public string productBrand { get; set; } = default!;
    public string productType { get; set; } = default!;
}
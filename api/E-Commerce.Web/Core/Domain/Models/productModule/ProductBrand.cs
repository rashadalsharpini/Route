namespace Domain.Models.productModule;

public class ProductBrand:BaseEntity<int>
{
    public string Name { get; set; } = default!;
}
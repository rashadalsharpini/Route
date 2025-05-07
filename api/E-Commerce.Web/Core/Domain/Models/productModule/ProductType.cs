namespace Domain.Models.productModule;

public class ProductType:BaseEntity<int>
{
    public string Name { get; set; } = default!;
}
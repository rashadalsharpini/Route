namespace Shared;

public class ProductQueryParams
{
    public int? BrandId { get; set; }
    public int? TypeId { get; set; }
    public ProductSortingOptions SortingOptions { get; set; }
    public string? SearchValue { get; set; }
    public int PageIndex { get; set; } = 1;
    private const int DefaultPageSize = 5;
    private const int MaxPageSize = 10;
    private int _pageSize;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}
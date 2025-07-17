namespace Shared;

public class ProductQueryParams
{
    public int? BrandId { get; set; }
    public int? TypeId { get; set; }
    public ProductSortingOptions sort { get; set; }
    public string? search { get; set; }
    public int pageNumber { get; set; } = 1;
    private const int DefaultPageSize = 5;
    private const int MaxPageSize = 10;
    private int _pageSize;

    public int PageSize
    {
        get => _pageSize == 0 ? DefaultPageSize : _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}
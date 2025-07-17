using Domain.Models.productModule;
using Shared;

namespace Service.Specifications;

class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product, int>
{
    // get all products with types and brands
    public ProductWithBrandAndTypeSpecifications(ProductQueryParams queryParams) :
        base(p => (!queryParams.BrandId.HasValue || p.BrandId == queryParams.BrandId) &&
                  (!queryParams.TypeId.HasValue || p.TypeId == queryParams.TypeId) &&
                  (string.IsNullOrWhiteSpace(queryParams.search) ||
                   p.Name.ToLower().Contains(queryParams.search.ToLower())))
    {
        AddInclude(p => p.ProductBrand);
        AddInclude(p => p.ProductType);
        switch (queryParams.sort)
        {
            case ProductSortingOptions.NameAsc:
                AddOrderBy(p => p.Name);
                break;
            case ProductSortingOptions.NameDesc:
                AddOrderByDes(p => p.Name);
                break;
            case ProductSortingOptions.PriceAsc:
                AddOrderBy(p => p.Price);
                break;
            case ProductSortingOptions.PriceDesc:
                AddOrderByDes(p => p.Price);
                break;
            default:
                break;
        }

        ApplyPagination(queryParams.PageSize, queryParams.pageNumber);
    }

    // get by id
    public ProductWithBrandAndTypeSpecifications(int id) : base(p => p.Id == id)
    {
        AddInclude(p => p.ProductBrand);
        AddInclude(p => p.ProductType);
    }
}
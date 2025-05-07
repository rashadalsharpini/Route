using Domain.Models;
using Domain.Models.productModule;
using Shared;

namespace Service.Specifications;

class ProductCountSpecification : BaseSpecifications<Product, int>
{
    public ProductCountSpecification(ProductQueryParams queryParams) :
        base(p => (!queryParams.BrandId.HasValue || p.BrandId == queryParams.BrandId) &&
                  (!queryParams.TypeId.HasValue || p.TypeId == queryParams.TypeId) &&
                  (string.IsNullOrWhiteSpace(queryParams.SearchValue) ||
                   p.Name.ToLower().Contains(queryParams.SearchValue.ToLower())))
    {
    }
}
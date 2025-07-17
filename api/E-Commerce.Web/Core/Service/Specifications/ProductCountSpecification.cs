using Domain.Models.productModule;
using Shared;

namespace Service.Specifications;

class ProductCountSpecification : BaseSpecifications<Product, int>
{
    public ProductCountSpecification(ProductQueryParams queryParams) :
        base(p => (!queryParams.BrandId.HasValue || p.BrandId == queryParams.BrandId) &&
                  (!queryParams.TypeId.HasValue || p.TypeId == queryParams.TypeId) &&
                  (string.IsNullOrWhiteSpace(queryParams.search) ||
                   p.Name.ToLower().Contains(queryParams.search.ToLower())))
    {
    }
}
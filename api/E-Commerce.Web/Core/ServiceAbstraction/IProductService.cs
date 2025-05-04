using Shared;
using Shared.DTOs;

namespace ServiceAbstraction;

public interface IProductService
{
    Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams);
    Task<IEnumerable<TypeDto>> GetAllTypesAsync();
    Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
    Task<ProductDto> GetProductByIdAsync(int id);
}
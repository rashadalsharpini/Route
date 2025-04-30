using Shared.DTOs;

namespace ServiceAbstraction;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<IEnumerable<TypeDto>> GetAllTypesAsync();
    Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
    Task<ProductDto> GetProductByIdAsync(int id);
}
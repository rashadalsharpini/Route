using AutoMapper;
using Domain.Contracts;
using Domain.Execptions;
using Domain.Models.productModule;
using Service.Specifications;
using ServiceAbstraction;
using Shared;
using Shared.DTOs.productDto;

namespace Service;

public class ProductService(IUnitOfWork uow, IMapper mapper) : IProductService
{
    public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams)
    {
        var repo = uow.GenericRepo<Product, int>();
        var specifications = new ProductWithBrandAndTypeSpecifications(queryParams);
        var products = await repo.GetAllAsync(specifications);
        var data = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
        var total = await repo.CountAsync(new ProductCountSpecification(queryParams));
        return new PaginatedResult<ProductDto>(queryParams.pageNumber, data.Count(), total, data);
    }

    public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
    {
        var types = await uow.GenericRepo<ProductType, int>().GetAllAsync();
        var typesDto = mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(types);
        return typesDto;
    }

    public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
    {
        var repo = uow.GenericRepo<ProductBrand, int>();
        var brands = await repo.GetAllAsync();
        var brandsDto = mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(brands);
        return brandsDto;
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var specifications = new ProductWithBrandAndTypeSpecifications(id);
        var product = await uow.GenericRepo<Product, int>().GetByIdAsync(specifications);
        if (product is null)
            throw new ProductNotFoundException(id);
        return mapper.Map<Product, ProductDto>(product);
    }
}
using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using ServiceAbstraction;
using Shared.DTOs;

namespace Service;

public class ProductService(IUnitOfWork uow, IMapper mapper):IProductService
{
    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await uow.GenericRepo<Product, int>().GetAllAsync();
        return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

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
        var product = await uow.GenericRepo<Product, int>().GetByIdAsync(id);
        return mapper.Map<Product, ProductDto>(product);
    }
}
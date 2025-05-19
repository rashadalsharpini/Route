using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DTOs.productDto;

namespace Presentation.Controllers;

public class ProductsController(IServiceManager serviceManager) : ApiBaseController
{
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<ProductDto>>> GetAllProducts([FromQuery] ProductQueryParams queryParams)
    {
        var products = await serviceManager.ProductService.GetAllProductsAsync(queryParams);
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await serviceManager.ProductService.GetProductByIdAsync(id);
        return Ok(product);
    }

    [HttpGet("types")]
    public async Task<ActionResult<IEnumerable<TypeDto>>> GetTypes()
    {
        var types = await serviceManager.ProductService.GetAllTypesAsync();
        return Ok(types);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
    {
        var brands = await serviceManager.ProductService.GetAllBrandsAsync();
        return Ok(brands);
    }
}
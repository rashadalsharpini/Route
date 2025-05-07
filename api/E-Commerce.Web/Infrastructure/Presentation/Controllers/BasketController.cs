using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTOs.BasketDto;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasketController(IServiceManager serviceManager):ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<BasketDto>> GetBasket(string id)
    {
        var basket = await serviceManager.BasketService.GetBasketAsync(id);
        return Ok(basket);
    }

    [HttpPost]
    public async Task<ActionResult<BasketDto>> CreateOrUpdateBasket([FromBody] BasketDto basket)
    {
        var Basket = await serviceManager.BasketService.CreateOrUpdateBasketAsync(basket);
        return Ok(Basket);
    }

    [HttpDelete("{Key}")]
    public async Task<ActionResult<bool>> DeleteBasket(string key)
    {
        var res = await serviceManager.BasketService.DeleteBasketAsync(key);
        return Ok(res);
    }
}
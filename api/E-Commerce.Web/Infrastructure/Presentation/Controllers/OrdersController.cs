using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTOs.OrderDtos;

namespace Presentation.Controllers;

[Authorize]
public class OrdersController(IServiceManager serviceManager) : ApiBaseController
{
    [HttpPost]
    public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto orderDto)
    {
        var order = await serviceManager.OrderService.CreateOrderAsync(orderDto, GetEmailFromToken());
        return Ok(order);
    }

    [AllowAnonymous]
    [HttpGet("DeliveryMethods")]
    public async Task<ActionResult<IEnumerable<DeliveryMethodDto>>> GetDeliveryMethods()
    {
        var methods = await serviceManager.OrderService.GetDeliveryMethodsAsync();
        return Ok(methods);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetAllOrders()
    {
        var orders = await serviceManager.OrderService.GetOrdersAsync(GetEmailFromToken());
        return Ok(orders);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderToReturnDto>> GetOrderById(Guid id)
    {
        var order = await serviceManager.OrderService.GetOrderByIdsAsync(id);
        return Ok(order);
    }
}
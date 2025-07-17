using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTOs.BasketDto;

namespace Presentation.Controllers;

public class PaymentsController(IServiceManager serviceManager) : ApiBaseController
{
    [Authorize]
    [HttpPost("{BasketId}")]
    public async Task<ActionResult<BasketDto>> CreateOrUpdatePaymentIntent(string BasketId)
    {
        var basket = await serviceManager.PaymentService.CreateOrUpdatePaymentIntentAsync(BasketId);
        return Ok(basket);
    }
}
using Shared.DTOs.BasketDto;

namespace ServiceAbstraction;

public interface IPaymentService
{
    Task<BasketDto> CreateOrUpdatePaymentIntentAsync(string basketId);
}
using Shared.DTOs.OrderDtos;

namespace ServiceAbstraction;

public interface IOrderService
{
    Task<OrderToReturnDto> CreateOrderAsync(OrderDto orderDto, string email);
    Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodsAsync();
    Task<IEnumerable<OrderToReturnDto>> GetOrdersAsync(string email);
    Task<OrderToReturnDto> GetOrderByIdsAsync(Guid id);
}
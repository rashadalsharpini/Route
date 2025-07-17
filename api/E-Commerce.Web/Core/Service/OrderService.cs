using AutoMapper;
using Domain.Contracts;
using Domain.Execptions;
using Domain.Models.OrderModel;
using Domain.Models.productModule;
using Service.Specifications;
using ServiceAbstraction;
using Shared.DTOs.IdentityDtos;
using Shared.DTOs.OrderDtos;

namespace Service;

public class OrderService(IMapper map, IBasketRepo basketRepo, IUnitOfWork uow) : IOrderService
{
    public async Task<OrderToReturnDto> CreateOrderAsync(OrderDto orderDto, string email)
    {
        var orderAddress = map.Map<AddressDto, OrderAddress>(orderDto.shipToAddress);
        var basket = await basketRepo.GetBasketAsync(orderDto.BasketId) ??
                     throw new BasketNotFoundException("Basket not found");
        ArgumentNullException.ThrowIfNull(basket.paymentIntentId);
        var orderRepo = uow.GenericRepo<Order, Guid>();
        var orderSpec = new OrderWithPaymentIntentIdSpecifications(basket.paymentIntentId);
        var ExistingOrder = await orderRepo.GetByIdAsync(orderSpec);
        if (ExistingOrder is not null) orderRepo.Remove(ExistingOrder);
        List<OrderItem> orderItems = [];
        var productRepo = uow.GenericRepo<Product, int>();
        foreach (var i in basket.Items)
        {
            var product = await productRepo.GetByIdAsync(i.Id) ?? throw new ProductNotFoundException(i.Id);
            var item = new OrderItem()
            {
                Product = new ProductItemOrder()
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    PictureUrl = product.PictureUrl
                },
                Price = product.Price,
                Quantity = i.Quantity
            };
            orderItems.Add(item);
        }

        var deliverMethod = await uow.GenericRepo<DeliveryMethod, int>().GetByIdAsync(orderDto.DeliveryMethodId) ??
                            throw new DeliveryMethodNotFound(orderDto.DeliveryMethodId);
        var subTotal = orderItems.Sum(i => i.Price * i.Quantity);
        var order = new Order(email, orderAddress, deliverMethod, orderItems, subTotal, basket.paymentIntentId);
        await orderRepo.AddAsync(order);
        await uow.SaveChangesAsync();
        return map.Map<Order, OrderToReturnDto>(order);
    }

    public async Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodsAsync()
    {
        var methods = await uow.GenericRepo<DeliveryMethod, int>().GetAllAsync();
        return map.Map<IEnumerable<DeliveryMethod>, IEnumerable<DeliveryMethodDto>>(methods);
    }

    public async Task<IEnumerable<OrderToReturnDto>> GetOrdersAsync(string email)
    {
        var spec = new OrderSpecifications(email);
        var orders = await uow.GenericRepo<Order, Guid>().GetAllAsync(spec);
        return map.Map<IEnumerable<Order>, IEnumerable<OrderToReturnDto>>(orders);
    }

    public async Task<OrderToReturnDto> GetOrderByIdsAsync(Guid id)
    {
        var spec = new OrderSpecifications(id);
        var order = await uow.GenericRepo<Order, Guid>().GetByIdAsync(spec);
        return map.Map<Order, OrderToReturnDto>(order);
    }
}
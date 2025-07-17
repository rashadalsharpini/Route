using AutoMapper;
using Domain.Contracts;
using Domain.Execptions;
using Domain.Models.OrderModel;
using Microsoft.Extensions.Configuration;
using ServiceAbstraction;
using Shared.DTOs.BasketDto;
using Stripe;
using Product = Domain.Models.productModule.Product;

namespace Service;

public class PaymentServicea(IConfiguration conf, IBasketRepo basketRepo, IUnitOfWork uow, IMapper map) : IPaymentService
{
    public async Task<BasketDto> CreateOrUpdatePaymentIntentAsync(string basketId)
    {
        StripeConfiguration.ApiKey = conf["StripeSettings:SecretKey"];
        var basket = await basketRepo.GetBasketAsync(basketId) ?? throw new BasketNotFoundException(basketId);
        var productRepo = uow.GenericRepo<Product, int>();
        foreach (var item in basket.Items)
        {
            var product = await productRepo.GetByIdAsync(item.Id) ?? throw new ProductNotFoundException(item.Id);
            item.Price = product.Price;
        }

        ArgumentNullException.ThrowIfNull(basket.deliveryMethodId);
        var delivermethod = await uow.GenericRepo<DeliveryMethod, int>().GetByIdAsync(basket.deliveryMethodId.Value)
                            ?? throw new DeliveryMethodNotFound(basket.deliveryMethodId.Value);
        basket.shippingPrice = delivermethod.Cost;
        var basketAmount = (long)(basket.Items.Sum(item=>item.Price * item.Quantity) + delivermethod.Cost)*100;
        var paymentService = new PaymentIntentService();
        if (basket.paymentIntentId is null)
        {
            var opt = new PaymentIntentCreateOptions()
            {
                Amount = basketAmount,
                Currency = "USD",
                PaymentMethodTypes = ["card"],
            };
            var paymentIntent = await paymentService.CreateAsync(opt);
            basket.clientSecret = paymentIntent.ClientSecret;
        }
        else
        {
            var opt = new PaymentIntentUpdateOptions()
            {
                Amount = basketAmount
            };
            await paymentService.UpdateAsync(basket.paymentIntentId, opt);
        }

        await basketRepo.CreateOrUpdateBasketAsync(basket);
        return map.Map<BasketDto>(basket);
    }
}
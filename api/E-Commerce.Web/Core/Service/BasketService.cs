using AutoMapper;
using Domain.Contracts;
using Domain.Execptions;
using Domain.Models.BasketModel;
using ServiceAbstraction;
using Shared.DTOs.BasketDto;

namespace Service;

public class BasketService(IBasketRepo basketRepo, IMapper mapper):IBasketService
{
    public async Task<BasketDto> GetBasketAsync(string Key)
    {
        var basket = await basketRepo.GetBasketAsync(Key);
        if(basket is not null)
            return mapper.Map<CustomerBasket, BasketDto>(basket);
        throw new BasketNotFoundException(Key);
    }

    public async Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket)
    {
        var customerBasket = mapper.Map<BasketDto, CustomerBasket>(basket);
        var isCreated = await basketRepo.CreateOrUpdateBasketAsync(customerBasket);
        if (isCreated is not null) return await GetBasketAsync(basket.Id);
        throw new Exception("Basket could not be created, try again later");
    }

    public async Task<bool> DeleteBasketAsync(string Key)
    {
        return await basketRepo.DeleteBasketAsync(Key);
    }
}
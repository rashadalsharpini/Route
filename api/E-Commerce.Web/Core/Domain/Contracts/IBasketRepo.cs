using Domain.Models.BasketModel;

namespace Domain.Contracts;

public interface IBasketRepo
{
    Task<CustomerBasket?> GetBasketAsync(string key);
    Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? time = null);
    Task<bool> DeleteBasketAsync(string key);
}
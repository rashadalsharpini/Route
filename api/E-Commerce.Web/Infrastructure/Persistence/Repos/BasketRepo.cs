using System.Text.Json;
using Domain.Contracts;
using Domain.Models.BasketModel;
using StackExchange.Redis;

namespace Persistence.Repos;

public class BasketRepo(IConnectionMultiplexer connection):IBasketRepo
{
    private readonly IDatabase _db = connection.GetDatabase();
    public async Task<CustomerBasket?> GetBasketAsync(string key)
    {
        var basket = await _db.StringGetAsync(key);
        if (basket.IsNullOrEmpty) return null;
        return JsonSerializer.Deserialize<CustomerBasket>(basket!);
    }

    public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? time = null)
    {
        var jsonRes = JsonSerializer.Serialize(basket);
        var isCreated = await _db.StringSetAsync(basket.Id, jsonRes, time ?? TimeSpan.FromDays(30));
        if(!isCreated) return null;
        return await GetBasketAsync(basket.Id);
    }

    public async Task<bool> DeleteBasketAsync(string key)
    {
        return await _db.KeyDeleteAsync(key);
    }
}
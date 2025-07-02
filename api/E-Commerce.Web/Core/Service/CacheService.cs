using System.Text.Json;
using Domain.Contracts;
using ServiceAbstraction;

namespace Service;

internal class CacheService(ICacheRepo cacheRepo):ICacheService
{
    public async Task<string?> GetAsync(string cacheKey)
    {
        return await cacheRepo.GetAsync(cacheKey);
    }

    public async Task SetAsync(string cacheKey, object cacheValue, TimeSpan expiry)
    {
        var value = JsonSerializer.Serialize(cacheValue);
        await cacheRepo.SetAsync(cacheKey, value, expiry);
    }
}
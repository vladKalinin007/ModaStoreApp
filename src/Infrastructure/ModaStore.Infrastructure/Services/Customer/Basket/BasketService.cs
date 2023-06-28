using System.Text.Json;
using ModaStore.Domain.Interfaces.Customer.Basket;
using StackExchange.Redis;
using BasketEntity = ModaStore.Domain.Entities.Customer.Basket.Basket;

namespace ModaStore.Infrastructure.Services.Customer.Basket;

public class BasketService : IBasketService
{
    private readonly IDatabase _database;

    public BasketService(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }

    public Task<BasketEntity> CreateBasketAsync(BasketEntity basket)
    {
        var created = _database.StringSet(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
        if (!created) return null;
        return GetBasketAsync(basket.Id);
    }

    public async Task<BasketEntity> GetBasketAsync(string basketId)
    {
        var data = await _database.StringGetAsync(basketId);
        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<BasketEntity>(data);
    }

    public async Task<BasketEntity> UpdateBasketAsync(BasketEntity basket)
    {
        await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
        return await GetBasketAsync(basket.Id);
    }

    public Task<bool> DeleteBasketAsync(string basketId)
    {
        return _database.KeyDeleteAsync(basketId);
    }
}
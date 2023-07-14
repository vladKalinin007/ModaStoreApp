using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Interfaces.Catalog;
using Newtonsoft.Json;
using StackExchange.Redis;
using CatalogProduct = ModaStore.Domain.Entities.Catalog.Product;

namespace ModaStore.Infrastructure.Services.Catalog.Product;

public class SeenProductService : ISeenProductService
{
    private readonly IDatabase _database;

    public SeenProductService(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }
    
    //Create
    public async Task<SeenProductsList> CreateSeenProductsAsync(SeenProductsList seenProducts)
    {
        var created = _database.StringSet(seenProducts.Id, SerializeSeenProducts(seenProducts), TimeSpan.FromDays(30));
        if (!created) return null;
        return await GetSeenProductsAsync(seenProducts.Id);
    } 
    
    //Read
    public async Task<SeenProductsList> GetSeenProductsAsync(string seenProductsId)
    {
        var data = await _database.StringGetAsync(seenProductsId);
        return await Task.FromResult(DeserializeSeenProducts(data));
    }

    // public Task<bool> AddProductToSeenProductsAsync(string id, SeenProduct product)
    // {
    //     throw new NotImplementedException();
    // }


    //Add product to seen products
    public async Task<bool> AddProductToSeenProductsAsync(string id, SeenProductsList seenProductsList)
    {
        var existing = await GetSeenProductsAsync(id);
        if (existing == null)
        {
            return false;
        }
        seenProductsList.Id = existing.Id;
        var json = SerializeSeenProducts(seenProductsList);
        return await _database.StringSetAsync(id, json);
    }
    
    //Updare(PUT)
    public async Task<bool> UpdateSeenProductsAsync(string id, SeenProductsList seenProducts)
    {
        var existing = await GetSeenProductsAsync(id);
        if (existing == null)
        {
            return false;
        }
        seenProducts.Id = existing.Id;
        var json = SerializeSeenProducts(seenProducts);
        return await _database.StringSetAsync(id, json);
    }
    
    //delete
    
    public async Task<bool> RemoveSeenProductsAsync(string id)
    {
        return await _database.KeyDeleteAsync(id);
    }

    private string SerializeSeenProducts(SeenProductsList seenProducts)
    {
        return JsonConvert.SerializeObject(seenProducts);
    }
    
    private SeenProductsList DeserializeSeenProducts(string json)
    {
        return JsonConvert.DeserializeObject<SeenProductsList>(json);
    }
}
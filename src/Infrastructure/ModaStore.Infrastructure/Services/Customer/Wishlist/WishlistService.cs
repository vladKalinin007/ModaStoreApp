using ModaStore.Domain.Entities.Customer.Wishlist;
using ModaStore.Domain.Interfaces.Customer.Wishlist;
using Newtonsoft.Json;
using StackExchange.Redis;
using WishlistEntity = ModaStore.Domain.Entities.Customer.Wishlist.Wishlist;

namespace ModaStore.Infrastructure.Services.Customer.Wishlist;

public class WishlistService : IWishlistService
{
    private readonly IDatabase _database;

    public WishlistService(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }
    

    public async Task<WishlistEntity> CreateWishlistAsync(WishlistEntity wishlist)
    {
        var created = _database.StringSet(wishlist.Id, SerializeWishlist(wishlist), TimeSpan.FromDays(30));
        if (!created) return null;
        return await GetWishlistAsync(wishlist.Id);
    }

    public async Task<WishlistEntity> GetWishlistAsync(string wishlistId)
    {
        var data = await _database.StringGetAsync(wishlistId);
        return await Task.FromResult(DeserializeWishlist(data));
    }

    public async Task<bool> RemoveWishlist(string userId)
    {
        var wishlistKey = GetWishlistKey(userId);
        return await _database.KeyDeleteAsync(wishlistKey);
    }
    
    public async Task<bool> AddItemToWishlist(string userId, WishlistItem item)
    {
        var wishlist = await GetWishlist(userId);
        wishlist.WishlistItems.Add(item);
        return await UpdateWishlist(userId, wishlist);
    }

    public async Task<bool> RemoveItemFromWishlist(string userId, WishlistItem item)
    {
        var wishlist = await GetWishlist(userId);
        wishlist.WishlistItems.Remove(item);
        return await UpdateWishlist(userId, wishlist);
    }

    public async Task<IEnumerable<WishlistItem>> GetWishlistItems(string userId)
    {
        var wishlist = await GetWishlist(userId);
        return wishlist.WishlistItems;
    }
    
    public async Task<bool> IsItemInWishlist(string userId, WishlistItem item)
    {
        var wishlist = await GetWishlist(userId);
        return wishlist.WishlistItems.Contains(item);
    }

    private async Task<WishlistEntity> GetWishlist(string userId)
    {
        var wishlistKey = GetWishlistKey(userId);
        var wishlistJson = await _database.StringGetAsync(wishlistKey);
        return wishlistJson.HasValue ? DeserializeWishlist(wishlistJson) : new WishlistEntity();
    }

    private async Task<bool> UpdateWishlist(string userId, WishlistEntity wishlist)
    {
        var wishlistKey = GetWishlistKey(userId);
        var wishlistJson = SerializeWishlist(wishlist);
        return await _database.StringSetAsync(wishlistKey, wishlistJson);
    }
    
    private string GetWishlistKey(string userId)
    {
        return $"wishlist:{userId}";
    }

    private string SerializeWishlist(WishlistEntity wishlist)
    {
        return JsonConvert.SerializeObject(wishlist);
    }

    private WishlistEntity DeserializeWishlist(string wishlistJson)
    {
        return JsonConvert.DeserializeObject<WishlistEntity>(wishlistJson); 
    }
}
// using ModaStore.Domain.Entities.Customer.Wishlist;

using ModaStore.Domain.Entities.Customer.Wishlist;
using WishlistEntity = ModaStore.Domain.Entities.Customer.Wishlist.Wishlist;

namespace ModaStore.Domain.Interfaces.Customer.Wishlist;

public interface IWishlistService
{
    Task<WishlistEntity> CreateWishlistAsync(WishlistEntity wishlist);
    Task<WishlistEntity> GetWishlistAsync(string wishlistId);
    Task<bool> RemoveWishlist(string userId);
    Task<bool> AddItemToWishlist(string userId, WishlistItem item);
    Task<bool> RemoveItemFromWishlist(string userId, WishlistItem item);
    Task<IEnumerable<WishlistItem>> GetWishlistItems(string userId);
    Task<bool> IsItemInWishlist(string userId, WishlistItem item);
}

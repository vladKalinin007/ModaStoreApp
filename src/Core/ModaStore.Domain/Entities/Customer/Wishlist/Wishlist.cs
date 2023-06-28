using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Customer.Wishlist;

public class Wishlist : BaseEntity
{
    public Wishlist()
    {
        
    }
    
    // public Wishlist(string userId)
    // {
    //     UserId = userId;
    // }
    
    // public string UserId { get; set; }
    
    public List<WishlistItem> Items { get; set; } = new List<WishlistItem>();
    

}
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Customer.Wishlist;

public class Wishlist : BaseEntity
{
    public Wishlist()
    {
        
    }
    
    
    public List<WishlistItem> WishlistItems { get; set; }
    

}
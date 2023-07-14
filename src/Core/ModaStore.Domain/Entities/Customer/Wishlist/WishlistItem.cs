using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Customer.Wishlist;

public class WishlistItem : BaseEntity
{
    public string ProductName { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public string ProductType { get; set; }
    public string ProductBrand { get; set; }
}
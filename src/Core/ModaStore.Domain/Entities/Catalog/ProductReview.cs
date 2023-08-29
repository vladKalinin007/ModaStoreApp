using ModaStore.Domain.Entities.Common;
using ModaStore.Domain.Entities.Identity;

namespace ModaStore.Domain.Entities.Catalog;

public class ProductReview : BaseEntity
{
    public int Rating { get; set; } 
    public string Comment { get; set; } 
    
    public string UserId { get; set; } 
    public AppUser User { get; set; } 

    public string ProductId { get; set; } 
    public Product Product { get; set; }
}

using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Entities.Common;
using ModaStore.Domain.Entities.Identity;


namespace ModaStore.Domain.Entities.Content;

public class Comment : BaseEntity
{
    public string Text { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    
    public string ProductId { get; set; }
    public Product Product { get; set; }
    
    public string UserId { get; set; }
    public AppUser AppUser { get; set; }
    
}
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class ProductFlag : BaseEntity
{
    public Product Product { get; set; }
    public string ProductId { get; set; }
    
    public Flag Flag { get; set; }
    public string FlagId { get; set; }
}
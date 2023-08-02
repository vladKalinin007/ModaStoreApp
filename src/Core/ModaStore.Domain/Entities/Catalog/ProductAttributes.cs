using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class ProductAttribute : BaseEntity
{
    public Product Product { get; set; }
    public string ProductId { get; set; }
    
    public Attributes Attributes { get; set; }
    public string AttributesId { get; set; }
}
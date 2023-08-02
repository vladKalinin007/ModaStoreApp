using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class ProductSize : BaseEntity
{
    public Product Product { get; set; }
    public string ProductId { get; set; }
    
    public Size Size { get; set; }
    public string SizeId { get; set; }
}
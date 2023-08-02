
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class ProductColor : BaseEntity
{
    public Product Product { get; set; }
    public string ProductId { get; set; }
    
    public Color Color { get; set; }
    public string ColorId { get; set; }
}
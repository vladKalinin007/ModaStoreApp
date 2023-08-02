using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class Size : BaseEntity
{
    public string Name { get; set; }
    public ICollection<ProductSize> ProductSizes { get; set; }
    public ICollection<Product> Products { get; set; }
}
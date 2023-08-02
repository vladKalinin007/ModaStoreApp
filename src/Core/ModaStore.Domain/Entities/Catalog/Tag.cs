using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class Tag : BaseEntity
{
    public string Name { get; set; }
    public ICollection<ProductTag> ProductTags { get; set; }
    public ICollection<Product> Products { get; set; }
}
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class Color : BaseEntity
{
    public string Name { get; set; }
    public string ColorCode { get; set; }
    public ICollection<ProductColor> ProductColors { get; set; }
    public ICollection<Product> Products { get; set; }
}
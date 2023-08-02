using ModaStore.Domain.Entities.Common;


namespace ModaStore.Domain.Entities.Catalog;

public class ProductType : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<CategoryProductType> CategoryProductTypes { get; set; }
}
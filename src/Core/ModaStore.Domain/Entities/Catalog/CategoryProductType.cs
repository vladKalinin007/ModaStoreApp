using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class CategoryProductType : BaseEntity
{
    public string CategoryId { get; set; }
    public Category Category { get; set; }

    public string ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }
}

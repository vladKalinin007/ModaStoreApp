using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class ProductCategory : BaseEntity
{
    public Product Product { get; set; }
    public string ProductId { get; set; }
    
    public Category Category { get; set; }
    public string CategoryId { get; set; }
}
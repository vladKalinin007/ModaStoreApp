using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class ProductTag : BaseEntity
{
    public Product Product { get; set; }
    public string ProductId { get; set; }
    
    public Tag Tag { get; set; }
    public string TagId { get; set; }
}
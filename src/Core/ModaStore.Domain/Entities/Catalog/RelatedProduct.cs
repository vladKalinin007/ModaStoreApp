using System.ComponentModel.DataAnnotations.Schema;
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class RelatedProducts : BaseEntity
{
    [ForeignKey("ProductId")]
    public string ProductId { get; set; }
    public Product Product { get; set; }
    
    [ForeignKey("RelatedProductId")]
    public string RelatedProductId { get; set; }
    public Product RelatedProduct { get; set; }
    
    
}
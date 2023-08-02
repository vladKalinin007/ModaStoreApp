
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Entities.Common;

public class ProductPicture : BaseEntity
{
    public string ProductId { get; set; }
    public Product Product { get; set; }
    
    public string PictureId { get; set; }
    public Picture Picture { get; set; }
}
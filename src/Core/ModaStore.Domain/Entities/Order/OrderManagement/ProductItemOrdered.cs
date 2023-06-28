using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Order.OrderManagement;

public class ProductItemOrdered 
{
    public ProductItemOrdered()
    {
        
    }
    
    public ProductItemOrdered(string productItemId, string productName, string pictureUrl)
    {
        ProductItemId = productItemId;
        ProductName = productName;
        PictureUrl = pictureUrl;
    }
    
    public string ProductItemId { get; set; }
    public string ProductName { get; set; }
    public string PictureUrl { get; set; }
}
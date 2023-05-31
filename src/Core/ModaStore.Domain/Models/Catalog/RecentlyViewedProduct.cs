namespace ModaStore.Domain.Models.Catalog;

public class RecentlyViewedProduct
{
    public string CustomerId { get; set; }
    public string ProductId { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}
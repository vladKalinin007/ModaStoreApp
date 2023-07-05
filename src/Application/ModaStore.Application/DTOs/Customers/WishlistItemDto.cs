namespace ModaStore.Application.DTOs.Customers;

public class WishlistItemDto
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public string ProductType { get; set; }
    public string ProductBrand { get; set; }
}
namespace ModaStore.Application.DTOs.Customers;

public class WishlistDto
{
    public string? Id { get; set; }
    public List<WishlistItemDto>? WishlistItems { get; set; } = new List<WishlistItemDto>();
}
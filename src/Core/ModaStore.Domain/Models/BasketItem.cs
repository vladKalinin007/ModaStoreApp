using System.ComponentModel.DataAnnotations;

namespace ModaStore.Domain.Models;

public class BasketItem
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    [Required]
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string PictureUrl { get; set; } 
    public string Brand { get; set; }
    public string Type { get; set; }
}
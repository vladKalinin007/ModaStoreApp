using System.ComponentModel.DataAnnotations;
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Customer.Basket;

public class BasketItem : BaseEntity
{
    public string ProductName { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    [Required]
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string PictureUrl { get; set; } 
    public string Brand { get; set; }
    public string Type { get; set; }
}
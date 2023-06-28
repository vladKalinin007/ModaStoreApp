using System.ComponentModel.DataAnnotations;
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Order.OrderManagement;

public class BasketItemDto : BaseDto
{
    
    [Required]
    public string ProductName { get; set; }
    
    [Required]
    [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }
    
    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }
    
    [Required]
    public string PictureUrl { get; set; }
    
    [Required]
    public string Brand { get; set; }
        
    [Required]
    public string Type { get; set; }
}
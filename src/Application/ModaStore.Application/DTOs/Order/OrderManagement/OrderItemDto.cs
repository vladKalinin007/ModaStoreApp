using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Order.OrderManagement;

public class OrderItemDto : BaseDto
{
    public string ProductName { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
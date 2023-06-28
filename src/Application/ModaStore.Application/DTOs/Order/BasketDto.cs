using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.DTOs.Order.OrderManagement;
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Order;

public class BasketDto : BaseDto
{
    public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    public string? DeliveryMethodId { get; set; }
    public string? ClientSecret { get; set; }
    public string? PaymentIntentId { get; set; }
    public decimal? ShippingPrice { get; set; }
}
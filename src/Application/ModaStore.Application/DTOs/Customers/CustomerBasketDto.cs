using ModaStore.Application.DTOs.Order.OrderManagement;
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Customers;

public class CustomerBasketDto : BaseDto
{
    public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    public int? DeliveryMethodId { get; set; }
    public string? ClientSecret { get; set; }
    public string? PaymentIntentId { get; set; }
    public decimal? ShippingPrice { get; set; }
}
using ModaStore.Domain.Entities.Common;
using ModaStore.Domain.Entities.Order.OrderManagement;

namespace ModaStore.Application.DTOs.Order.OrderManagement;

public class OrderToReturnDto : BaseDto
{
    public string BuyerEmail { get; set; }
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public AddressDto ShipToAddress { get; set; }
    public string DeliveryMethod { get; set; }
    public decimal ShippingPrice { get; set; }
    public IReadOnlyList<OrderItemDto> OrderItems { get; set; }
    public decimal Subtotal { get; set; }
    public string Status { get; set; }
    public decimal Total { get; set; }
}
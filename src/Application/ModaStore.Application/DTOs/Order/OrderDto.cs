using ModaStore.Application.DTOs.Order.OrderManagement;
using ModaStore.Domain.Entities.Common;
using ModaStore.Domain.Entities.Order.OrderManagement;

namespace ModaStore.Application.DTOs.Order;

public class OrderDto
{
    public string Email { get; set; }
    public string BasketId { get; set; }
    public string DeliveryMethodId { get; set; }
    public AddressDto ShipToAddress { get; set; }
}
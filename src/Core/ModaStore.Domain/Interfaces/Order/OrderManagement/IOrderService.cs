using ModaStore.Domain.Entities.Order.OrderManagement;
using OrderEntity = ModaStore.Domain.Entities.Order.OrderManagement.Order;

namespace ModaStore.Domain.Interfaces.Order.OrderManagement;

public interface IOrderService
{
    Task<OrderEntity> CreateOrderAsync(string buyerEmail, string deliveryMethodId, string basketId, Address shippingAddress);
    Task<IList<OrderEntity>> GetOrdersForUserAsync(string buyerEmail);
    Task<OrderEntity> GetOrderByIdAsync(string id, string buyerEmail);
    Task<OrderEntity> UpdateOrderAsync(OrderEntity order);
    Task<bool> DeleteOrderAsync(string id, string buyerEmail);
}
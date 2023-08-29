using ModaStore.Domain.Entities.Customer.Basket;
using OrderEntity = ModaStore.Domain.Entities.Order.OrderManagement.Order;

namespace ModaStore.Domain.Interfaces.Order.Payment;

public interface IPaymentService
{
    Task<Basket> CreateOrUpdatePaymentIntent(string basketId);
    // Task<OrderEntity> UpdateOrderPaymentSucceeded(string paymentIntentId);
    // Task<OrderEntity> UpdateOrderPaymentFailed(string paymentIntentId);
}
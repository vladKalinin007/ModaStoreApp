using ModaStore.Domain.Models;
using ModaStore.Domain.Models.OrderAggregate;

namespace ModaStore.Domain.Interfaces;

public interface IPaymentService
{
    Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
    Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId);
    Task<Order> UpdateOrderPaymentFailed(string paymentIntentId);
}
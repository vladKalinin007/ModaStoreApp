using ModaStore.Domain.Entities.Order.OrderManagement;

namespace ModaStore.Domain.Interfaces.Order.Shipping;

public interface IDeliveryService
{
    Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    Task<DeliveryMethod> GetDeliveryMethodByIdAsync(int id);
}
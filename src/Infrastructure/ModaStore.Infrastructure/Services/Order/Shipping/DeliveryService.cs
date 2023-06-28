using ModaStore.Domain.Entities.Order.OrderManagement;
using ModaStore.Domain.Interfaces.Order.Shipping;

namespace ModaStore.Infrastructure.Services.Order.Shipping;

public class DeliveryService : IDeliveryService
{
    public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<DeliveryMethod> GetDeliveryMethodByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
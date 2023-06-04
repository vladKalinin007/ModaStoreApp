using ModaStore.Domain.Interfaces;
using ModaStore.Domain.Models;

namespace ModaStore.Infrastructure.Services;

public class RecentlyViewedProductService : IRecentlyViewedProductsService
{
    public Task<IList<Product>> GetRecentlyViewedProducts(string customerId, int number)
    {
        throw new NotImplementedException();
    }

    public Task AddProductToRecentlyViewedList(string customerId, string productId)
    {
        throw new NotImplementedException();
    }
}
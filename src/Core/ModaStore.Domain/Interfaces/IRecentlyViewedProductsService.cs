using ModaStore.Domain.Models;

namespace ModaStore.Domain.Interfaces;

public interface IRecentlyViewedProductsService
{
    Task<IList<Product>> GetRecentlyViewedProducts(string customerId, int number);
    
    Task AddProductToRecentlyViewedList(string customerId, string productId);
}
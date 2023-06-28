using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Domain.Interfaces.Catalog;

public interface IRecentlyViewedProductsService
{
    Task<IList<Product>> GetRecentlyViewedProducts(string customerId, int number);
    
    Task AddProductToRecentlyViewedList(string customerId, string productId);
    
    
}
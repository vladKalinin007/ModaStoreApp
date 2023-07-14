using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Domain.Interfaces.Catalog;

public interface ISeenProductService
{
    Task<SeenProductsList> CreateSeenProductsAsync(SeenProductsList seenProducts);
    Task<SeenProductsList> GetSeenProductsAsync(string seenProductsId);
    Task<bool> AddProductToSeenProductsAsync(string id, SeenProductsList product);
    Task<bool> UpdateSeenProductsAsync(string id, SeenProductsList seenProducts);
    Task<bool> RemoveSeenProductsAsync(string id);
}
using Core.Models;

namespace Core.Interfaces;

public interface IProductRepository
{
    Task<Product> GetProductsByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetProductsAsync();
}
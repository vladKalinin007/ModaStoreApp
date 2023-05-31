using ModaStore.Domain.Models;

namespace ModaStore.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> GetProductsByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetProductsAsync();
    Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
}
using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Domain.Interfaces.Catalog;

public interface IProductService
{
    #region Products
    
    Task<IList<Product>> GetAllProducts();
    Task<Product> GetProductById(string productId);
    Task InsertProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(Product product);
    Task<ProductAttributes> GetAttributes();
    
    #endregion
}
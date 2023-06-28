using ModaStore.Domain.Interfaces.Catalog;
using ModaStore.Domain.Interfaces.Data;

namespace ModaStore.Infrastructure.Services.Catalog.Product;

public class ProductService : IProductService
{
    private readonly IRepository<Domain.Entities.Catalog.Product> _productRepository;

    public ProductService(IRepository<Domain.Entities.Catalog.Product> productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IList<Domain.Entities.Catalog.Product>> GetAllProducts()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Domain.Entities.Catalog.Product> GetProductById(string productId)
    {
        return await _productRepository.GetByIdAsync(productId);
    }

    public Task InsertProduct(Domain.Entities.Catalog.Product product)
    {
        return _productRepository.InsertAsync(product);
    }

    public Task UpdateProduct(Domain.Entities.Catalog.Product product)
    {
        return _productRepository.UpdateAsync(product);
    }

    public Task DeleteProduct(Domain.Entities.Catalog.Product product)
    {
        return _productRepository.DeleteAsync(product);
    }
}
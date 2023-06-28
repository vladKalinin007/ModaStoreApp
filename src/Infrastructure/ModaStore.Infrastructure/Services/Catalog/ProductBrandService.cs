using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Interfaces.Catalog;
using ModaStore.Domain.Interfaces.Data;

namespace ModaStore.Infrastructure.Services.Catalog;

public class ProductBrandService : IProductBrandService
{
    private readonly IRepository<ProductBrand> _productBrandRepository;
    
    public ProductBrandService(IRepository<ProductBrand> productBrandRepository)
    {
        _productBrandRepository = productBrandRepository;
    }
    
    public async Task<IList<ProductBrand>> GetAllProductBrands()
    {
        return await _productBrandRepository.GetAllAsync();
    }

    public Task<ProductBrand> GetProductBrandById(string productBrandId)
    {
       return _productBrandRepository.GetByIdAsync(productBrandId);
    }

    public Task InsertProductBrand(ProductBrand productBrand)
    {
        return _productBrandRepository.InsertAsync(productBrand);
    }

    public Task UpdateProductBrand(ProductBrand productBrand)
    {
        return _productBrandRepository.UpdateAsync(productBrand);
    }

    public Task DeleteProductBrand(ProductBrand productBrand)
    {
        return _productBrandRepository.DeleteAsync(productBrand);
    }
}
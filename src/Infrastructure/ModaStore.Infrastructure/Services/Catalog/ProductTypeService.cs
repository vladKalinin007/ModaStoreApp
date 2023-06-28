using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Interfaces.Catalog;
using ModaStore.Domain.Interfaces.Data;

namespace ModaStore.Infrastructure.Services.Catalog;

public class ProductTypeService : IProductTypeService
{
    private readonly IRepository<ProductType> _productTypeRepository;
    
    public ProductTypeService(IRepository<ProductType> productTypeRepository)
    {
        _productTypeRepository = productTypeRepository;
    }
    
    public async Task<IList<ProductType>> GetAllProductTypes()
    {
        return await _productTypeRepository.GetAllAsync();
    }

    public Task<ProductType> GetProductTypeById(string productTypeId)
    {
        return _productTypeRepository.GetByIdAsync(productTypeId);
    }

    public Task InsertProductType(ProductType productType)
    {
        return _productTypeRepository.InsertAsync(productType);
    }

    public Task UpdateProductType(ProductType productType)
    {
        return _productTypeRepository.UpdateAsync(productType);
    }

    public Task DeleteProductType(ProductType productType)
    {
        return _productTypeRepository.DeleteAsync(productType);
    }
}
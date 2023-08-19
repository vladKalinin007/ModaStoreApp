using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Interfaces.Catalog;
using ModaStore.Domain.Interfaces.Data;

namespace ModaStore.Infrastructure.Services.Catalog;

public class ProductTypeService : IProductTypeService
{
    private readonly IRepository<CategoryProductType> _categoryProductTypeRepository;
    private readonly IRepository<ProductType> _productTypeRepository;
    
    public ProductTypeService(
        IRepository<CategoryProductType> categoryProductTypeRepository,
        IRepository<ProductType> productTypeRepository)
    {
        _categoryProductTypeRepository = categoryProductTypeRepository;
        _productTypeRepository = productTypeRepository;
    }
    
    public async Task<IList<ProductType>> GetAllProductTypes()
    {
        return await _productTypeRepository.GetAllAsync();
    }

    public IQueryable<ProductType> GetProductTypesByCategory(string category)
    {
        var categoryId = _productTypeRepository.GetAllQueryAsync()
            .Where(x => x.CategoryProductTypes.Any(y => y.Category.Name == category))
            .Select(x => x.CategoryProductTypes.FirstOrDefault(y => y.Category.Name == category).CategoryId)
            .FirstOrDefault();

        return _productTypeRepository.GetAllQueryAsync()
            .Where(x => x.CategoryProductTypes.Any(y => y.CategoryId == categoryId));
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
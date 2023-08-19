using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Domain.Interfaces.Catalog;

public interface IProductTypeService
{
    Task<IList<ProductType>> GetAllProductTypes();
    IQueryable<ProductType> GetProductTypesByCategory(string category);
    Task<ProductType> GetProductTypeById(string productTypeId);
    Task InsertProductType(ProductType productType);
    Task UpdateProductType(ProductType productType);
    Task DeleteProductType(ProductType productType);
}
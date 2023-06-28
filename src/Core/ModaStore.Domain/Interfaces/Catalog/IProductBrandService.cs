using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Domain.Interfaces.Catalog;

public interface IProductBrandService
{
    Task <IList<ProductBrand>> GetAllProductBrands();
    Task<ProductBrand> GetProductBrandById(string productBrandId);
    Task InsertProductBrand(ProductBrand productBrand);
    Task UpdateProductBrand(ProductBrand productBrand);
    Task DeleteProductBrand(ProductBrand productBrand);
}
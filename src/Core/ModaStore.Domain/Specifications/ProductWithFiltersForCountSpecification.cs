using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Domain.Specifications;

public class ProductWithFiltersForCountSpecification: BaseSpecification<Entities.Catalog.Product>
{
    public ProductWithFiltersForCountSpecification(ProductSpecParams? productParams):
        base(x => 
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (string.IsNullOrEmpty(productParams.BrandId) || x.ProductBrandId == productParams.BrandId) && 
            (string.IsNullOrEmpty(productParams.TypeId) || x.ProductTypeId == productParams.TypeId))  
    {
        
    }
}
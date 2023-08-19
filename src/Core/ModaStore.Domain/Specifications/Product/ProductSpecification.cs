namespace ModaStore.Domain.Specifications.Product;
using Product = Entities.Catalog.Product;

public class ProductSpecification : BaseSpecification<Product>
{
    // Single product
    public ProductSpecification(string id) : base(x => x.Id == id)
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.Category);
        AddInclude(x => x.ProductColors);
        AddInclude(x => x.ProductSizes);
        AddInclude(x => x.ProductTags);
        AddInclude(x => x.ProductPictures);
        AddInclude(x => x.ProductReviews);
        AddInclude(x => x.RelatedProducts);
    }
    
    // Multiple products
    public ProductSpecification(ProductSpecParams? productParams): 
        base(x => 
               (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) 
            && (string.IsNullOrEmpty(productParams.BrandId) || x.ProductBrandId == productParams.BrandId) 
            && (string.IsNullOrEmpty(productParams.TypeId) || x.ProductTypeId == productParams.TypeId)
            && (string.IsNullOrEmpty(productParams.CategoryId) || x.CategoryId == productParams.CategoryId) 
           && (string.IsNullOrEmpty(productParams.Category) || x.Category.Name == productParams.Category)
           && (string.IsNullOrEmpty(productParams.ColorId) || x.ProductColors.Any(c => c.ColorId == productParams.ColorId))
           && (string.IsNullOrEmpty(productParams.SizeId) || x.ProductSizes.Any(s => s.SizeId == productParams.SizeId))
               
                
        )
        
{
    AddInclude(x => x.ProductType);
    AddInclude(x => x.ProductBrand);
    AddInclude(x => x.Category);
    AddInclude(x => x.ProductColors); 
    AddInclude(x => x.ProductSizes); 
    AddInclude(x => x.ProductTags); 
    AddInclude(x => x.ProductPictures);
    AddInclude(x => x.ProductReviews); 
    AddInclude(x => x.RelatedProducts); 
    
    
    AddOrderBy(x => x.Name);
    ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

    if (productParams?.Sort != null) 
    {
        switch (productParams.Sort)
        {
            case "priceAsc":
                AddOrderBy(p => p.Price);
                break;
            case "priceDesc": 
                AddOrderByDescending(p => p.Price);
                break;
            default:
                AddOrderBy(n => n.Name);
                break;
        }
    }
    
    // FILTERS 
    
    if (productParams?.Category != null)
    {
        AddCriterias(x => x.Category.Name == productParams.Category);
    }
    
    if (productParams?.Brand != null)
    {
        AddCriterias(x => x.ProductBrand.Name == productParams.Brand);
    }
    
    if (productParams?.Type != null)
    {
        AddCriterias(x => x.ProductType.Name == productParams.Type);
    }

    if (productParams?.SizeId != null)
    {
        AddCriterias(x => x.ProductSizes
            .Any(ps => ps.ProductId == x.Id || ps.SizeId == productParams.SizeId));
    }

    if (productParams?.IsNew != null)
    {
        AddCriterias(x => x.IsNew == productParams.IsNew);
    }
    
    if (productParams?.IsBestSeller != null)
    {
        AddCriterias(x => x.IsBestSeller == productParams.IsBestSeller);
    }

    if (productParams?.ColorId != null)
    {
            AddCriterias(x => x.ProductColors
            .Any(pc => pc.ProductId == x.Id || pc.ColorId == productParams.ColorId));
    }
    
    if (productParams?.Season != null)
    {
        AddCriterias(x => x.Season == productParams.Season);
    }
    
    if (productParams?.Pattern != null)
    {
        AddCriterias(x => x.Pattern == productParams.Pattern);
    }
    
    if (productParams?.Style != null)
    {
        AddCriterias(x => x.Style == productParams.Style);
    }
    
    if (productParams?.Material != null)
    {
        AddCriterias(x => x.Material == productParams.Material);
    }
    
    if (productParams?.MinPrice != null && productParams?.MaxPrice != null)
    {
        AddCriterias(x => x.Price >= productParams.MinPrice && x.Price <= productParams.MaxPrice);
    }
}
}
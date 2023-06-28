using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Entities.Common;


namespace ModaStore.Domain.Entities.Catalog;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUrl { get; set; }
    public ProductType ProductType { get; set; }
    public string ProductTypeId { get; set; }
    public ProductBrand ProductBrand { get; set; }
    public string ProductBrandId { get; set; }
    
    // public string Color { get; set; }
    // public string Size { get; set; }    
    // public string Season { get; set; }
    // public string Material { get; set; }
    // public string Style { get; set; }
    // public string Pattern { get; set; }
    // public string Occasion { get; set; }
    
    // public bool ShowOnHomePage { get; set; }
    // public bool BestSeller { get; set; }
    // public string MetaKeywords { get; set; }
    // public bool AllowCustomerReviews { get; set; }
    // public bool DisableBuyButton { get; set; }
    // public double OldPrice { get; set; }
    // public bool MarkAsNew { get; set; }
    // public DateTime CreatedOnUtc { get; set; }
    // public DateTime UpdatedOnUtc { get; set; }
    // public string ShortDescription { get; set; }
    // public virtual ICollection<ProductPicture> ProductPictures
    // {
    //     get { return _productPictures ??= new List<ProductPicture>(); }
    //     protected set { _productPictures = value; }
    // }
    // public virtual ICollection<string> ProductTags
    // {
    //     get { return _productTags ??= new List<string>(); }
    //     protected set { _productTags = value; }
    // }
    // public virtual ICollection<RelatedProduct> RelatedProducts
    // {
    //     get { return _relatedProduct ??= new List<RelatedProduct>(); }
    //     protected set { _relatedProduct = value; }
    // }
}
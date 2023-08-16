using ModaStore.Domain.Entities.Common;
using ModaStore.Domain.Entities.Content;


namespace ModaStore.Domain.Entities.Catalog;

    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public string? PictureUrl { get; set; }
        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
        public int? StockQuantity { get; set; }
        public int? DisplayOrder { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }    
        public string? Season { get; set; }
        public string? Material { get; set; }
        public string? Style { get; set; }
        public string? Pattern { get; set; }
        public string? Occasion { get; set; }
        public string? Sleeve { get; set; }
        public string? Neckline { get; set; }
        public string? DressLength { get; set; }
        public string? Waistline { get; set; }
        public string? Silhouette { get; set; }
        public string? Decoration { get; set; }
        public string? ClosureType { get; set; }
        public string? PantClosureType { get; set; }
        public string? PantLength { get; set; }
        public string? PantStyle { get; set; }
        public string? FitType { get; set; }
        public bool? Published { get; set; }
        public bool? Deleted { get; set; }
        public bool? IsFeatured { get; set; }
        public bool? IsCallForPricing { get; set; }
            public bool? IsOnSale { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsBestSeller { get; set; }
        public bool? IsGiftCard { get; set; }
        public bool? IsDownload { get; set; }
        public bool? IsRecurring { get; set; }
        public bool? IsShipEnabled { get; set; }
        public bool? IsFreeShipping { get; set; }
        public bool? IsOnHomePage { get; set; }
        public bool? IsOnSalePage { get; set; }
        public bool? AllowCustomerReviews { get; set; }
        public bool? DisableBuyButton { get; set; }
        public bool? DisableWishlistButton { get; set; }
        public bool? DisableCompareButton { get; set; }
        public bool? ShowOnHomePage { get; set; }
        public bool? ShowOnSalePage { get; set; }


        // Navigation properties
        
        // One to one +
        public ProductType ProductType { get; set; }
        public Category Category { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public string ProductBrandId { get; set; }
        public string ProductTypeId { get; set; }
        public string CategoryId { get; set; }

        // One to many
        public ICollection<ProductReview> ProductReviews { get; set; }
        public int TotalRating => ProductReviews?.Sum(pr => pr.Rating) ?? 0;
        public ICollection<RelatedProducts> RelatedProducts { get; set; }
        
        // Many to many
        public ICollection<ProductPicture> ProductPictures { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public ICollection<Size> Sizes { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<Color> Colors { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
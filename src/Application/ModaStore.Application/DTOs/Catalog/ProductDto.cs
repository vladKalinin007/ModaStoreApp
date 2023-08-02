using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Catalog;

public class ProductDto : BaseDto
{
    public string? Name { get; set; }
    public string? ProductType { get; set; }
    public string? ProductBrand { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public decimal? OldPrice { get; set; }
    public decimal? SpecialPrice { get; set; }
    public decimal? DiscountPercentage { get; set; }
    public string? PictureUrl { get; set; }
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
    public bool? Deleted { get; set; }
    public bool? IsOnSale { get; set; }
    public bool? IsNew { get; set; }
    public bool? IsBestSeller { get; set; }
    public ICollection<PictureDto>? Pictures { get; set; }
    public ICollection<TagDto>? Tags { get; set; }
    public ICollection<ReviewDto>? Reviews { get; set; }
    public ICollection<ColorDto>? Colors { get; set; }
    public ICollection<SizeDto>? Sizes { get; set; }
    public ICollection<RelatedProductDto>? RelatedProducts { get; set; }
}
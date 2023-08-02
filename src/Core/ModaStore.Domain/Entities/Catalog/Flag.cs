using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class Flag : BaseEntity
{
    public bool Published { get; set; }
    public bool Deleted { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsCallForPricing { get; set; }
    public bool IsOnSale { get; set; }
    public bool IsNew { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsGiftCard { get; set; }
    public bool IsRental { get; set; }
    public bool IsDownload { get; set; }
    public bool IsRecurring { get; set; }
    public bool IsShipEnabled { get; set; }
    public bool IsTaxExempt { get; set; }
    public bool IsFreeShipping { get; set; }
    public bool IsOnHomePage { get; set; }
    public bool IsOnCategoryPage { get; set; }
    public bool IsOnManufacturerPage { get; set; }
    public bool IsOnSalePage { get; set; }
    public bool AllowCustomerReviews { get; set; }
    public bool DisableBuyButton { get; set; }
    public bool DisableWishlistButton { get; set; }
    public bool DisableCompareButton { get; set; }
    public bool ShowOnHomePage { get; set; }
    public bool ShowOnSalePage { get; set; }
    public bool ShowOnCategoryPage { get; set; }
    public bool ShowOnManufacturerPage { get; set; }
    public bool ShowOnSearchPage { get; set; }
    public bool ShowOnProductPage { get; set; }
    public bool ShowOnCartPage { get; set; }
}
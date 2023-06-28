using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Customer.Basket;

public class Basket : BaseEntity
{
    public Basket()
    {
        
    }

    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    public string? DeliveryMethodId { get; set; }
    public string? ClientSecret { get; set; }
    public string? PaymentIntentId { get; set; }
    public decimal? ShippingPrice { get; set; }
}


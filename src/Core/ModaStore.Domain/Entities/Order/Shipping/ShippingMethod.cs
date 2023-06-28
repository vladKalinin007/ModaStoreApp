using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Order.Shipping;

public class ShippingMethod : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    // Дополнительные свойства и методы
}
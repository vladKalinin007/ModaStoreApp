using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Order.Shipping;

public class ShippingAddress : BaseEntity
{
    public string UserId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    
    // Дополнительные свойства и методы
}
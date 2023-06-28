using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Order.OrderManagement;

public class DeliveryMethod : BaseEntity
{
    public string ShortName { get; set; }
    public string DeliveryTime { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
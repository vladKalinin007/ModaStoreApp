using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Order.Discount;

public class Coupon : BaseEntity
{
    public string Code { get; set; }
    public decimal DiscountAmount { get; set; }
    public DateTime ExpirationDate { get; set; }
    
    // Дополнительные свойства и методы
}
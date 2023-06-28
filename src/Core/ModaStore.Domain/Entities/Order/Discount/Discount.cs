using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Order.Discount;

public class Discount : BaseEntity
{
    public string Code { get; set; }
    public decimal Percentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    // Дополнительные свойства и методы
}
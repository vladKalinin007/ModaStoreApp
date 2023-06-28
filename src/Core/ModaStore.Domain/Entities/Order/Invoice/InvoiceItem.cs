using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Order.Invoice;

public class InvoiceItem : BaseEntity
{
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    
    // Дополнительные свойства и методы
}
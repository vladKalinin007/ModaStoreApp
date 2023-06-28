using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Order.Invoice;

public class Invoice : BaseEntity
{
    public string InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<InvoiceItem> Items { get; set; }
    
    // Дополнительные свойства и методы
}
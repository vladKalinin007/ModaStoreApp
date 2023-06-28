using ModaStore.Domain.Entities.Order.OrderManagement;


namespace ModaStore.Domain.Specifications;

public class OrderByPaymentIntentIdWithItemsSpecification : BaseSpecification<Order>
{
    public OrderByPaymentIntentIdWithItemsSpecification(string paymentIntentId): base(o => o.PaymentIntentId == paymentIntentId)
    {
        // AddInclude(o => o.DeliveryMethod);
        // AddInclude(o => o.OrderItems);
        // AddInclude(o => o.Address);
    }

}
using Core.Models.OrderAggregate;

namespace Core.Specifications;

public class OrderByPaymentIntentIdWithItemsSpecification : BaseSpecification<Order>
{
    public OrderByPaymentIntentIdWithItemsSpecification(string paymentIntentId): base(o => o.PaymentIntentId == paymentIntentId)
    {
        // AddInclude(o => o.DeliveryMethod);
        // AddInclude(o => o.OrderItems);
        // AddInclude(o => o.Address);
    }

}
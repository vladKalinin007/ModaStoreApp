using ModaStore.Domain.Entities.Customer.Basket;
using ModaStore.Domain.Entities.Order.OrderManagement;
using ModaStore.Domain.Interfaces.Customer.Basket;
using ModaStore.Domain.Interfaces.Data;
using ModaStore.Domain.Interfaces.Order.OrderManagement;
using ModaStore.Domain.Interfaces.Order.Payment;
using ModaStore.Domain.Specifications;
using OrderEntity = ModaStore.Domain.Entities.Order.OrderManagement.Order;

namespace ModaStore.Infrastructure.Services.Order.OrderManagement;

public class OrderService : IOrderService
{
    private readonly IBasketService _basketService;
    private readonly IRepository<OrderEntity> _orderRepository;
    private readonly IRepository<DeliveryMethod> _deliveryRepository;
    private readonly IPaymentService _paymentService;
    
    public OrderService(IBasketService basketService, IRepository<OrderEntity> orderRepository, IRepository<DeliveryMethod> deliveryRepository, IPaymentService paymentService)
    {
        _basketService = basketService;
        _orderRepository = orderRepository;
        _deliveryRepository = deliveryRepository;
        _paymentService = paymentService;
    }
    
    public async Task<OrderEntity> CreateOrderAsync(string buyerEmail, string deliveryMethodId, string basketId, Address shippingAddress)
    {
        var basket = await _basketService.GetBasketAsync(basketId);
        
        var items = new List<OrderItem>();

        foreach (var item in basket.Items)
        {
            var productItem = await _orderRepository.GetByIdAsync(item.Id);
            var itemOrdered = new ProductItemOrdered(item.Id, item.ProductName, item.PictureUrl);
            var orderItem = new OrderItem(itemOrdered, item.Price, item.Quantity);
            
            items.Add(orderItem);
        }
        
        var deliveryMethod = await _deliveryRepository.GetByIdAsync(deliveryMethodId);
        
        var subtotal = items.Sum(item => item.Price * item.Quantity);
        
        var spec = new OrderByPaymentIntentIdWithItemsSpecification(basket.PaymentIntentId);
        
        var existingOrder = await _orderRepository.GetEntityWithSpec(spec);
        
        if (existingOrder != null)
        {
            _orderRepository.Delete(existingOrder);
            await _paymentService.CreateOrUpdatePaymentIntent(basket.PaymentIntentId);
        }
        
        var order = new OrderEntity(items, buyerEmail, shippingAddress, deliveryMethod, subtotal, basket.PaymentIntentId);
        
        

        await _orderRepository.InsertAsync(order);
        
        
        return order;
        
        
           
    }

    public async Task<IList<OrderEntity>> GetOrdersForUserAsync(string buyerEmail)
    {
        var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);
        return await _orderRepository.GetAllWithSpecAsync(spec);
    }

    public async Task<OrderEntity> GetOrderByIdAsync(string id, string buyerEmail)
    {
        var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);
        return await _orderRepository.GetEntityWithSpec(spec);
    }

    public Task<OrderEntity> UpdateOrderAsync(OrderEntity order)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteOrderAsync(string id, string buyerEmail)
    {
        throw new NotImplementedException();
    }
}
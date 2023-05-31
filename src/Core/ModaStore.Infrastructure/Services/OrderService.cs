using ModaStore.Domain.Interfaces;
using ModaStore.Domain.Models;
using ModaStore.Domain.Models.OrderAggregate;
using ModaStore.Domain.Specifications;

namespace ModaStore.Infrastructure.Services;

public class OrderService : IOrderService
{
    #region Fields

    private readonly IUnitOfWork _unitOfWork;
    private readonly IBasketRepository _basketRepo;
    private readonly IPaymentService _paymentService;

    #endregion

    #region Constructor

    public OrderService(
        IUnitOfWork unitOfWork,
        IBasketRepository basketRepo,
        IPaymentService paymentService
        )
    {
        _unitOfWork = unitOfWork;
        _basketRepo = basketRepo;
        _paymentService = paymentService;
    }

    #endregion

    #region Methods

    public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
    {
        var basket = await _basketRepo.GetBasketAsync(basketId);
        
        var items = new List<OrderItem>(); 
        
        foreach (var item in basket.Items)
        {
            var productItem = await _unitOfWork.Repository<Product>().getByIdAsync(item.Id);
            var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
            var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
            
            items.Add(orderItem);
        }
        
        var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().getByIdAsync(deliveryMethodId);
        
        var subtotal = items.Sum(item => item.Price * item.Quantity);
        
        var spec = new OrderByPaymentIntentIdWithItemsSpecification(basket.PaymentIntentId);
        
        var existingOrder = await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        
        if (existingOrder != null)
        {
            _unitOfWork.Repository<Order>().Delete(existingOrder);
            await _paymentService.CreateOrUpdatePaymentIntent(basket.PaymentIntentId);
        }
        
        var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal, basket.PaymentIntentId);
        
        _unitOfWork.Repository<Order>().Add(order);
        
        var result = await _unitOfWork.Complete();
        
        if (result <= 0) return null;

        return order;
    }

    public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
    {
        var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);
        return await _unitOfWork.Repository<Order>().ListAsync(spec);
    }

    public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
    {
        var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);
        return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
    }

    public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
    {
        return await _unitOfWork.Repository<DeliveryMethod>().ListAllAsync();
    }

    #endregion
}
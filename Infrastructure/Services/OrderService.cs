using Core.Interfaces;
using Core.Models;
using Core.Models.OrderAggregate;
using Core.Specifications;

namespace Infrastructure.Services;

public class OrderService : IOrderService
{
    #region Fields

    private readonly IUnitOfWork _unitOfWork;
    private readonly IBasketRepository _basketRepo;

    #endregion

    #region Constructor

    public OrderService(
        IUnitOfWork unitOfWork,
        IBasketRepository basketRepo)
    {
        _unitOfWork = unitOfWork;
        _basketRepo = basketRepo;
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
        
        var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal);
        
        _unitOfWork.Repository<Order>().Add(order);
        
        var result = await _unitOfWork.Complete();
        
        if (result <= 0) return null;
        
        await _basketRepo.DeleteBasketAsync(basketId);
        
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
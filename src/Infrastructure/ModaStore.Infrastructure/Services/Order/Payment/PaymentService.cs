using Microsoft.Extensions.Configuration;
using ModaStore.Domain.Entities.Customer.Basket;
using ModaStore.Domain.Entities.Order.OrderManagement;
using ModaStore.Domain.Interfaces.Common;
using ModaStore.Domain.Interfaces.Customer.Basket;
using ModaStore.Domain.Interfaces.Order.Payment;
using ModaStore.Domain.Specifications;
using ModaStore.Domain.Interfaces.Data;
using ModaStore.Domain.Entities.Catalog;
using Product = ModaStore.Domain.Entities.Catalog.Product;

using Stripe;

namespace ModaStore.Infrastructure.Services.Order.Payment;

public class PaymentService : IPaymentService
{
    private readonly IBasketService _basketService;
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<DeliveryMethod> _deliveryMethodRepository;

    private readonly IConfiguration _config;

    public PaymentService(IBasketService basketService, IRepository<Product> productRepository, IRepository<DeliveryMethod> deliveryMethodRepository, IConfiguration config)
    {
        _basketService = basketService;
        _productRepository = productRepository;
        _deliveryMethodRepository = deliveryMethodRepository;
        _config = config;
    }
    
    
    public async Task<Basket> CreateOrUpdatePaymentIntent(string basketId)
    {
        StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];
        
        var basket = await _basketService.GetBasketAsync(basketId);

        if (basket == null) return null;
        var shippingPrice = 0m;
        
        if (!string.IsNullOrWhiteSpace(basket.DeliveryMethodId))
        {
            var deliveryMethod = await _deliveryMethodRepository.GetByIdAsync(basket.DeliveryMethodId);
            shippingPrice = deliveryMethod.Price;
        }
        
        foreach (var item in basket.Items)
        {
            var productItem = await _productRepository.GetByIdAsync(item.Id);
            if (item.Price != productItem.Price)
            {
                item.Price = productItem.Price ?? 0;
            }
        }
        
        var service = new PaymentIntentService();
        
        PaymentIntent intent;
        
        if (string.IsNullOrEmpty(basket.PaymentIntentId))
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long) basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long) shippingPrice * 100,
                Currency = "usd",
                PaymentMethodTypes = new List<string> {"card"}
            };
            
            intent = await service.CreateAsync(options);
            basket.PaymentIntentId = intent.Id;
            basket.ClientSecret = intent.ClientSecret;
        }
        else
        {
            var options = new PaymentIntentUpdateOptions
            {
                Amount = (long) basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long) shippingPrice * 100
            };
            await service.UpdateAsync(basket.PaymentIntentId, options);
        }
        
        await _basketService.UpdateBasketAsync(basket);
        
        return basket;
    }

    // public async Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId)
    // {
    //     var spec = new OrderByPaymentIntentIdWithItemsSpecification(paymentIntentId);
    //     var order = await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        
    //     if (order == null) return null;
        
    //     order.Status = OrderStatus.PaymentReceived;
    //     _unitOfWork.Repository<Order>().Update(order);
        
    //     await _unitOfWork.Complete();
    
    //     return null;
    
    // }
    

}
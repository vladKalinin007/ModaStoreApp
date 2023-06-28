using Microsoft.Extensions.Configuration;
using ModaStore.Domain.Entities.Customer.Basket;
using ModaStore.Domain.Entities.Order.OrderManagement;
using ModaStore.Domain.Interfaces.Common;
using ModaStore.Domain.Interfaces.Order.Payment;
using ModaStore.Domain.Specifications;
using Stripe;

namespace ModaStore.Infrastructure.Services.Order.Payment;

public class PaymentService : IPaymentService
{
    // private readonly IBasketRepository _basketRepository;
    // private readonly IUnitOfWork _unitOfWork;
    // private readonly IConfiguration _config;
    //
    // public PaymentService(IBasketRepository basketRepository, IUnitOfWork unitOfWork, IConfiguration config)
    // {
    //     _basketRepository = basketRepository;
    //     _unitOfWork = unitOfWork;
    //     _config = config;
    // }
    // public async Task<Basket> CreateOrUpdatePaymentIntent(string basketId)
    // {
    //     StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];
    //     
    //     var basket = await _basketRepository.GetBasketAsync(basketId);
    //     if (basket == null) return null;
    //     var shippingPrice = 0m;
    //     
    //     if (!string.IsNullOrWhiteSpace(basket.DeliveryMethodId))
    //     {
    //         var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().getByIdAsync(basket.DeliveryMethodId);
    //         shippingPrice = deliveryMethod.Price;
    //     }
    //     
    //     foreach (var item in basket.Items)
    //     {
    //         var productItem = await _unitOfWork.Repository<Product>().getByIdAsync(item.Id);
    //         if (item.Price != productItem.Price)
    //         {
    //             item.Price = productItem.Price;
    //         }
    //     }
    //     
    //     var service = new PaymentIntentService();
    //     
    //     PaymentIntent intent;
    //     
    //     if (string.IsNullOrEmpty(basket.PaymentIntentId))
    //     {
    //         var options = new PaymentIntentCreateOptions
    //         {
    //             Amount = (long) basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long) shippingPrice * 100,
    //             Currency = "usd",
    //             PaymentMethodTypes = new List<string> {"card"}
    //         };
    //         
    //         intent = await service.CreateAsync(options);
    //         basket.PaymentIntentId = intent.Id;
    //         basket.ClientSecret = intent.ClientSecret;
    //     }
    //     else
    //     {
    //         var options = new PaymentIntentUpdateOptions
    //         {
    //             Amount = (long) basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long) shippingPrice * 100
    //         };
    //         await service.UpdateAsync(basket.PaymentIntentId, options);
    //     }
    //     
    //     await _basketRepository.UpdateBasketAsync(basket);
    //     
    //     return basket;
    // }

    // public async Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId)
    // {
    //     var spec = new OrderByPaymentIntentIdWithItemsSpecification(paymentIntentId);
    //     var order = await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
    //     
    //     if (order == null) return null;
    //     
    //     order.Status = OrderStatus.PaymentReceived;
    //     _unitOfWork.Repository<Order>().Update(order);
    //     
    //     await _unitOfWork.Complete();
    //
    //     return null;
    //
    // }
    //
    // public async Task<Order> UpdateOrderPaymentFailed(string paymentIntentId)
    // {
    //     var spec = new OrderByPaymentIntentIdWithItemsSpecification(paymentIntentId);
    //     var order = await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
    //     
    //     if (order == null) return null;
    //     
    //     order.Status = OrderStatus.PaymentFailed;
    //     
    //     await _unitOfWork.Complete();
    //     
    //     return order;
    // }
    public Task<Basket> CreateOrUpdatePaymentIntent(string basketId)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Order.OrderManagement.Order> UpdateOrderPaymentSucceeded(string paymentIntentId)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Order.OrderManagement.Order> UpdateOrderPaymentFailed(string paymentIntentId)
    {
        throw new NotImplementedException();
    }
}
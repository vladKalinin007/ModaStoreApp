using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModaStore.API.Errors;
using ModaStore.Domain.Interfaces;
using ModaStore.Domain.Models;
using Stripe;
using Order = ModaStore.Domain.Models.OrderAggregate.Order;

namespace ModaStore.API.Controllers.MdControllers;

public class PaymentController : BaseApiController
{
    private readonly IPaymentService _paymentService;
    private readonly ILogger<IPaymentService> _logger;
    private const string WhSecret = "whsec_...";

    public PaymentController(
        IPaymentService paymentService,
        ILogger<IPaymentService> logger)
    {
        _paymentService = paymentService;
        _logger = logger;
    }
    
    [Authorize]
    [HttpPost("{basketId}")]
    public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId)
    {
        var basket = await _paymentService.CreateOrUpdatePaymentIntent(basketId);

        if (basket == null) return BadRequest(new ApiResponse(400, "Problem with your basket"));

        return basket;
    }
    
    [HttpPost("webhook")]
    public async Task<ActionResult> StripeWebHook()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

        var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], WhSecret);

        PaymentIntent intent;
        Order order;

        switch (stripeEvent.Type)
        {
            case "payment_intent.succeeded":
                intent = (PaymentIntent) stripeEvent.Data.Object;
                _logger.LogInformation("Payment Succeeded: ", intent.Id);
                order = await _paymentService.UpdateOrderPaymentSucceeded(intent.Id);
                _logger.LogInformation("Order updated to payment received: ", order.Id);
                break;
            case "payment_intent.payment_failed":
                intent = (PaymentIntent) stripeEvent.Data.Object;
                _logger.LogInformation("Payment Failed: ", intent.Id);
                order = await _paymentService.UpdateOrderPaymentFailed(intent.Id);
                _logger.LogInformation("Payment Failed: ", order.Id);
                break;
        }

        return new EmptyResult();
    }
    
}
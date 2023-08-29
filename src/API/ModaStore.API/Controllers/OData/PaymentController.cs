using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ModaStore.Application.Features.Order.Payment.Commands.Models;
using Stripe;
using Swashbuckle.AspNetCore.Annotations;

namespace ModaStore.API.Controllers.OData;

public class PaymentController : BaseODataController
{
    private readonly IMediator _mediator;
    
    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("{basketId}")]
    public async Task<IActionResult> Post(string basketId)
    {
        return Ok(await _mediator.Send(new CreateOrUpdatePaymentIntentCommand(basketId)));
    }
    
    // [HttpPost("Webhook")]
    // public async Task<ActionResult> StripeWebHook()
    // {
    //     var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
    //
    //     var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], WhSecret);
    //
    //     switch (stripeEvent.Type)
    //     {
    //         case "payment_intent.succeeded":
    //             var intent = (PaymentIntent)stripeEvent.Data.Object;
    //             await _mediator.Send(new PaymentSucceededCommand { PaymentIntentId = intent.Id });
    //             break;
    //         case "payment_intent.payment_failed":
    //             var intent = (PaymentIntent)stripeEvent.Data.Object;
    //             await _mediator.Send(new PaymentFailedCommand { PaymentIntentId = intent.Id });
    //             break;
    //     }
    //
    //     return new EmptyResult();
    // }

}
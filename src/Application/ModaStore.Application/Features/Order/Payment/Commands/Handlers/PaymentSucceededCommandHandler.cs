// using MediatR;
// using Microsoft.Extensions.Logging;
// using ModaStore.Application.Features.Order.Payment.Commands.Models;
// using ModaStore.Domain.Interfaces.Order.Billing;
//
// namespace ModaStore.Application.Features.Order.Payment.Commands.Handlers;
//
// public class PaymentSucceededCommandHandler : IRequestHandler<PaymentSucceededCommand>
// {
//     private readonly IPaymentService _paymentService;
//     private readonly ILogger<PaymentSucceededCommandHandler> _logger;
//
//     public PaymentSucceededCommandHandler(IPaymentService paymentService, ILogger<PaymentSucceededCommandHandler> logger)
//     {
//         _paymentService = paymentService;
//         _logger = logger;
//     }
//
//     public async Task<Unit> Handle(PaymentSucceededCommand request, CancellationToken cancellationToken)
//     {
//         _logger.LogInformation("Payment Succeeded: {PaymentIntentId}", request.PaymentIntentId);
//         Order order = await _paymentService.UpdateOrderPaymentSucceeded(request.PaymentIntentId);
//         _logger.LogInformation("Order updated to payment received: {OrderId}", order.Id);
//         return Unit.Value;
//     }
// }
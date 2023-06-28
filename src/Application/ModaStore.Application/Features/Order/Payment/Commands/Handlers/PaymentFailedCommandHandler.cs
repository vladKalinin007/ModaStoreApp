// using MediatR;
// using Microsoft.Extensions.Logging;
// using ModaStore.Application.Features.Order.Payment.Commands.Models;
// using ModaStore.Domain.Interfaces.Order.Billing;
//
// namespace ModaStore.Application.Features.Order.Payment.Commands.Handlers;
//
// public class PaymentFailedCommandHandler : IRequestHandler<PaymentFailedCommand>
// {
//     private readonly IPaymentService _paymentService;
//     private readonly ILogger<PaymentFailedCommandHandler> _logger;
//
//     public PaymentFailedCommandHandler(IPaymentService paymentService, ILogger<PaymentFailedCommandHandler> logger)
//     {
//         _paymentService = paymentService;
//         _logger = logger;
//     }
//
//     public async Task<Unit> Handle(PaymentFailedCommand request, CancellationToken cancellationToken)
//     {
//         _logger.LogInformation("Payment Failed: {PaymentIntentId}", request.PaymentIntentId);
//         Order order = await _paymentService.UpdateOrderPaymentFailed(request.PaymentIntentId);
//         _logger.LogInformation("Payment Failed for Order: {OrderId}", order.Id);
//         return Unit.Value;
//     }
// }
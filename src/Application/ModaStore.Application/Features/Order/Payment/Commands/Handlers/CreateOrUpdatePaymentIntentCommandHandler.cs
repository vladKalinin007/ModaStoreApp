using MediatR;
using ModaStore.Application.Features.Order.Payment.Commands.Models;
using ModaStore.Domain.Entities.Customer.Basket;
using ModaStore.Domain.Interfaces.Order.Payment;

namespace ModaStore.Application.Features.Order.Payment.Commands.Handlers;

public class CreateOrUpdatePaymentIntentCommandHandler : IRequestHandler<CreateOrUpdatePaymentIntentCommand, Basket>
{
    private readonly IPaymentService _paymentService;
    
    public CreateOrUpdatePaymentIntentCommandHandler(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    
    public async Task<Basket> Handle(CreateOrUpdatePaymentIntentCommand request, CancellationToken cancellationToken)
    {
        var basket = await _paymentService.CreateOrUpdatePaymentIntent(request.BasketId);

        return basket;
    }
}

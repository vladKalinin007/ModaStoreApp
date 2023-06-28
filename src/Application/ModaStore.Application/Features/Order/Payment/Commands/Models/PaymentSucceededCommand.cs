using MediatR;

namespace ModaStore.Application.Features.Order.Payment.Commands.Models;

public class PaymentSucceededCommand : IRequest
{
    public string PaymentIntentId { get; set; }
}
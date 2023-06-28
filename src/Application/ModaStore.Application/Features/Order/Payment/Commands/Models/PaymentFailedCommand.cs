using MediatR;

namespace ModaStore.Application.Features.Order.Payment.Commands.Models;

public class PaymentFailedCommand : IRequest
{
    public string PaymentIntentId { get; set; }
}
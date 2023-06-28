using MediatR;
using ModaStore.Domain.Entities.Customer.Basket;

namespace ModaStore.Application.Features.Order.Payment.Commands.Models;

public class CreateOrUpdatePaymentIntentCommand : IRequest<Basket>
{
    public CreateOrUpdatePaymentIntentCommand(string basketId)
    {
        BasketId = basketId;
    }

    public string BasketId { get; set; }
}
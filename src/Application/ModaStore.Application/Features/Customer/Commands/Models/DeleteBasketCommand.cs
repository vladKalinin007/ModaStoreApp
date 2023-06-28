using MediatR;
using ModaStore.Application.DTOs.Order;

namespace ModaStore.Application.Features.Customer.Commands.Models;

public class DeleteBasketCommand : IRequest<bool>
{
    public DeleteBasketCommand(string id)
    {
        Id = id;
    }
    
    public string Id { get; set; }
}
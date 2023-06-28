using MediatR;
using ModaStore.Application.DTOs.Order;

namespace ModaStore.Application.Features.Customer.Commands.Models;

public class CreateBasketCommand : IRequest<BasketDto>
{
    public CreateBasketCommand(BasketDto basketDto, string? id = null)
    {
        BasketDto = basketDto;
        Id = id;
    }

    
    public BasketDto BasketDto { get; set; }
    public string? Id { get; set; }
}
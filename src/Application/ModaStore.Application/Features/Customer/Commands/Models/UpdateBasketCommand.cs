using MediatR;
using ModaStore.Application.DTOs.Order;

namespace ModaStore.Application.Features.Customer.Commands.Models;

public class UpdateBasketCommand : IRequest<BasketDto>
{
    public UpdateBasketCommand(BasketDto basketDto, string id)
    {
        BasketDto = basketDto;
        Id = id;
    }
    
    public BasketDto BasketDto { get; set; }
    public string Id { get; set; }
}
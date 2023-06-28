using MediatR;
using ModaStore.Application.DTOs.Order;

namespace ModaStore.Application.Features.Customer.Queries.Models;

public class GetBasketByIdQuery : IRequest<BasketDto>
{
    public GetBasketByIdQuery(string id)
    {
        Id = id;
    }
    
    public string Id { get; set; }
}
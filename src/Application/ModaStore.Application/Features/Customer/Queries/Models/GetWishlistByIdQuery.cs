using MediatR;
using ModaStore.Application.DTOs.Customers;

namespace ModaStore.Application.Features.Customer.Queries.Models;

public class GetWishlistByIdQuery : IRequest<WishlistDto>
{
    public GetWishlistByIdQuery(string id)
    {
        Id = id;
    }
    
    public string Id { get; set; }
}
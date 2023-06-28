using MediatR;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Domain.Entities.Customer.Wishlist;

namespace ModaStore.Application.Features.Customer.Commands.Models;

public class UpdateWishlistCommand : IRequest<WishlistDto>
{
    public UpdateWishlistCommand(WishlistDto wishlistDto, string id)
    {
        WishlistDto = wishlistDto;
        Id = id;
    }
    
    public WishlistDto WishlistDto { get; set; }
    public string Id { get; set; }
}
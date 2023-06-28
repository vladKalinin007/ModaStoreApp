using MediatR;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Domain.Entities.Customer.Wishlist;

namespace ModaStore.Application.Features.Customer.Commands.Models;

public class CreateWishlistCommand : IRequest<WishlistDto>
{
    public CreateWishlistCommand(WishlistDto wishlistDto, string? id = null)
    {
        WishlistDto = wishlistDto;
        Id = id;
    }

    public WishlistDto WishlistDto { get; set; }
    public string? Id { get; set; }
}
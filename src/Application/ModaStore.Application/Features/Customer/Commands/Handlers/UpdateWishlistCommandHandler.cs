using MediatR;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.Features.Customer.Commands.Models;
using ModaStore.Domain.Entities.Customer.Wishlist;
using ModaStore.Domain.Interfaces.Customer.Wishlist;

namespace ModaStore.Application.Features.Customer.Commands.Handlers;

public class UpdateWishlistCommandHandler : IRequestHandler<UpdateWishlistCommand, WishlistDto>
{
    private readonly IWishlistService _wishlistService;
    
    public UpdateWishlistCommandHandler(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }
    
    public Task<WishlistDto> Handle(UpdateWishlistCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
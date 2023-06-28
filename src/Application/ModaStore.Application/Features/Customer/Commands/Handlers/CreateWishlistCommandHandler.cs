using MediatR;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Customer.Commands.Models;
using ModaStore.Domain.Interfaces.Customer.Wishlist;

namespace ModaStore.Application.Features.Customer.Commands.Handlers;

public class CreateWishlistCommandHandler : IRequestHandler<CreateWishlistCommand, WishlistDto>
{
    private readonly IWishlistService _wishlistService;
    
    public CreateWishlistCommandHandler(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }
    
    public async Task<WishlistDto> Handle(CreateWishlistCommand request, CancellationToken cancellationToken)
    {
        var wishlist = request.WishlistDto.ToEntity();
        
        if (request.Id != null)
        {
            wishlist.Id = request.Id;
        }
        
        var result = await _wishlistService.CreateWishlistAsync(wishlist);
        
        return result.ToDto();
    }
}
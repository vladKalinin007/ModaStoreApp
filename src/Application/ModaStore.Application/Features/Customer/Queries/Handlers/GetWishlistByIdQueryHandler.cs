using MediatR;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Customer.Queries.Models;
using ModaStore.Domain.Interfaces.Customer.Wishlist;

namespace ModaStore.Application.Features.Customer.Queries.Handlers;

public class GetWishlistByIdQueryHandler : IRequestHandler<GetWishlistByIdQuery, WishlistDto>
{
    private readonly IWishlistService _wishlistService;
    
    public GetWishlistByIdQueryHandler(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }
    
    public async Task<WishlistDto> Handle(GetWishlistByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _wishlistService.GetWishlistAsync(request.Id);
        
        return result.ToDto();
    }
}
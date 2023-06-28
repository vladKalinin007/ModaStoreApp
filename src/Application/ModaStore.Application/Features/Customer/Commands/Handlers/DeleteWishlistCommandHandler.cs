using MediatR;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.Features.Customer.Commands.Models;
using ModaStore.Domain.Interfaces.Customer.Wishlist;

namespace ModaStore.Application.Features.Customer.Commands.Handlers;

public class DeleteWishlistCommandHandler : IRequestHandler<DeleteWishlistCommand, bool>
{
    private readonly IWishlistService _wishlistService;
    
    public DeleteWishlistCommandHandler(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }
    
    public Task<bool> Handle(DeleteWishlistCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

using MediatR;
using ModaStore.Application.Features.Customer.Commands.Models;
using ModaStore.Domain.Interfaces.Customer.Basket;

namespace ModaStore.Application.Features.Customer.Commands.Handlers;

public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, bool>
{
    private readonly IBasketService _basketService;
    
    public DeleteBasketCommandHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }
    
    public Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        return _basketService.DeleteBasketAsync(request.Id);
    }
}
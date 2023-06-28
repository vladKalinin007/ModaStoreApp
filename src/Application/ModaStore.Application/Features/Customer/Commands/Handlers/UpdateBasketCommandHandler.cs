using MediatR;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Customer.Commands.Models;
using ModaStore.Domain.Interfaces.Customer.Basket;

namespace ModaStore.Application.Features.Customer.Commands.Handlers;

public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, BasketDto>
{
    private readonly IBasketService _basketService;
    
    public UpdateBasketCommandHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }
    
    public async Task<BasketDto> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = request.BasketDto.ToEntity();
        
        if (request.Id != null)
        {
            basket.Id = request.Id;
        }
        
        var result = await _basketService.UpdateBasketAsync(basket);
        
        return result.ToDto();
    }
}
using MediatR;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Customer.Commands.Models;
using ModaStore.Domain.Interfaces.Customer.Basket;

namespace ModaStore.Application.Features.Customer.Commands.Handlers;

public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, BasketDto>
{
    private readonly IBasketService _basketService;
    
    public CreateBasketCommandHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }
    
    public async Task<BasketDto> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = request.BasketDto.ToEntity();
        
        if (request.Id != null)
        {
            basket.Id = request.Id;
        }
        
        var result = await _basketService.CreateBasketAsync(basket);
        
        return result.ToDto();
    }
}

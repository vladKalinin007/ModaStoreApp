using MediatR;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Customer.Queries.Models;
using ModaStore.Domain.Interfaces.Customer.Basket;

namespace ModaStore.Application.Features.Customer.Queries.Handlers;

public class GetBasketByIdQueryHandler : IRequestHandler<GetBasketByIdQuery, BasketDto>
{
    private readonly IBasketService _basketService;
    
    public GetBasketByIdQueryHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }
    
    public async Task<BasketDto> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
    {
        var basket = await _basketService.GetBasketAsync(request.Id);
        return basket.ToDto();
    }
}
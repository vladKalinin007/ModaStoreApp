using MediatR;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.DTOs.Order.OrderManagement;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Order.OrderManagement.Queries.Models;
using ModaStore.Domain.Interfaces.Order.OrderManagement;

namespace ModaStore.Application.Features.Order.OrderManagement.Queries.Handlers;

public class GetOrdersForUserQueryHandler : IRequestHandler<GetOrdersForUserQuery, List<OrderToReturnDto>>
{
    private readonly IOrderService _orderService;
    
    
    public GetOrdersForUserQueryHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    
    public async Task<List<OrderToReturnDto>> Handle(GetOrdersForUserQuery request, CancellationToken cancellationToken)
    {
        var email = request.Email;
        
        var orders = await _orderService.GetOrdersForUserAsync(email);

        return orders.ToDtoList();
    }
}
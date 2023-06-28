using MediatR;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.DTOs.Order.OrderManagement;
using ModaStore.Application.Features.Order.OrderManagement.Queries.Models;
using ModaStore.Domain.Interfaces.Order.OrderManagement;

namespace ModaStore.Application.Features.Order.OrderManagement.Queries.Handlers;

public class GetOrderByIdForUserQueryHandler : IRequestHandler<GetOrderByIdForUserQuery, OrderToReturnDto>
{
    private readonly IOrderService _orderService;
    
    public GetOrderByIdForUserQueryHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    public Task<OrderToReturnDto> Handle(GetOrderByIdForUserQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
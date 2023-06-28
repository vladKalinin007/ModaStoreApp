using MediatR;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.DTOs.Order.OrderManagement;

namespace ModaStore.Application.Features.Order.OrderManagement.Commands.Models;

public class UpdateOrderCommand : IRequest<OrderToReturnDto>
{
    public OrderDto Model { get; set; }
    
    public UpdateOrderCommand(OrderDto model)
    {
        Model = model;
    }
}
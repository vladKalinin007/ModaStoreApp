using MediatR;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.DTOs.Order.OrderManagement;

namespace ModaStore.Application.Features.Order.OrderManagement.Commands.Models;

public class CreateOrderCommand : IRequest<OrderToReturnDto>
{
    public OrderDto OrderDto { get; set; }

    public CreateOrderCommand(OrderDto orderDto)
    {
        OrderDto = orderDto;
    }
}
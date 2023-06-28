// using MediatR;
// using ModaStore.Application.DTOs.Order;
// using ModaStore.Application.Features.Order.OrderManagement.Commands.Models;
// using ModaStore.Domain.Interfaces.Order.OrderManagement;
//
// namespace ModaStore.Application.Features.Order.OrderManagement.Commands.Handlers;
//
// public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderDto>
// {
//     private readonly IOrderService _orderService;
//         
//     public Task<OrderDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
//     {
//        var order = _orderService.UpdateOrder(request.Model);
//     }
// }

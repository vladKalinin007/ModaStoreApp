using AutoMapper;
using MediatR;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.DTOs.Order.OrderManagement;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Order.OrderManagement.Commands.Models;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Entities.Order.OrderManagement;
using ModaStore.Domain.Interfaces.Order.OrderManagement;

namespace ModaStore.Application.Features.Order.OrderManagement.Commands.Handlers;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderToReturnDto>
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }
    
    public async Task<OrderToReturnDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var email = request.OrderDto.Email;
        var deliveryMethodId = request.OrderDto.DeliveryMethodId;
        var basketId = request.OrderDto.BasketId;
        var shipToAddress = request.OrderDto.ShipToAddress.ToEntity();
        
        var order = await _orderService.CreateOrderAsync(email, deliveryMethodId, basketId, shipToAddress);

        return order.ToDto();
    }
}
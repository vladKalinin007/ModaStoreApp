using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.DTOs.Order.OrderManagement;
using ModaStore.Application.Extensions;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Order.OrderManagement.Commands.Models;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Entities.Order.OrderManagement;
using ModaStore.Domain.Interfaces.Identity.Authentication;
using ModaStore.Domain.Interfaces.Order.OrderManagement;

namespace ModaStore.Application.Features.Order.OrderManagement.Commands.Handlers;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderToReturnDto>
{
    private readonly IOrderService _orderService;
    private readonly ICurrentUserService _currentUserService;
    private readonly UserManager<AppUser> _userManager;

    public CreateOrderCommandHandler(IOrderService orderService, ICurrentUserService currentUserService, UserManager<AppUser> userManager)
    {
        _orderService = orderService;
        _currentUserService = currentUserService;
        _userManager = userManager;
    }
    
    public async Task<OrderToReturnDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmaiWithAdressAsync(_currentUserService.User);
        
        var email = user.Email; 
        var deliveryMethodId = request.OrderDto.DeliveryMethodId;
        var basketId = request.OrderDto.BasketId;
        var shipToAddress = request.OrderDto.ShipToAddress.ToEntity();
        shipToAddress.AppUserId = user.Id;
        
        var order = await _orderService.CreateOrderAsync(email, deliveryMethodId, basketId, shipToAddress);

        return order.ToDto();
    }
}
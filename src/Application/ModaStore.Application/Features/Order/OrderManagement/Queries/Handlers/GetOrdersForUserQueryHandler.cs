using MediatR;
using ModaStore.Application.DTOs.Order.OrderManagement;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Order.OrderManagement.Queries.Models;
using ModaStore.Domain.Interfaces.Identity.Authentication;
using ModaStore.Domain.Interfaces.Order.OrderManagement;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.Extensions;
using ModaStore.Domain.Entities.Identity;



namespace ModaStore.Application.Features.Order.OrderManagement.Queries.Handlers;

public class GetOrdersForUserQueryHandler : IRequestHandler<GetOrdersForUserQuery, List<OrderToReturnDto>>
{
    private readonly IOrderService _orderService;
    private readonly ICurrentUserService _currentUserService;
    private readonly UserManager<AppUser> _userManager;
    
    
    public GetOrdersForUserQueryHandler(IOrderService orderService, ICurrentUserService currentUserService, UserManager<AppUser> userManager)
    {
        _orderService = orderService;
        _currentUserService = currentUserService;
        _userManager = userManager;
    }
    
    
    public async Task<List<OrderToReturnDto>> Handle(GetOrdersForUserQuery request, CancellationToken cancellationToken)
    {
        var email = _userManager.FindByEmaiWithAdressAsync(_currentUserService.User).Result.Email;
        
        var orders = await _orderService.GetOrdersForUserAsync(email);

        return orders.ToDtoList();
    }
}
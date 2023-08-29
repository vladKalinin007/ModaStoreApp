using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.Extensions;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Identity.User.Queries.Models;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Entities.Order.OrderManagement;
using ModaStore.Domain.Interfaces.Customer.Management;
using ModaStore.Domain.Interfaces.Data;
using ModaStore.Domain.Interfaces.Identity.Authentication;

namespace ModaStore.Application.Features.Identity.User.Queries.Handlers;

public class GetUserAddressQueryHandler : IRequestHandler<GetUserAddressQuery, AddressDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICurrentUserService  _currentUserService;
    private readonly IAddressService _addressService;
        
    public GetUserAddressQueryHandler(UserManager<AppUser> userManager, ICurrentUserService currentUserService, IAddressService addressService)
    {
        _userManager = userManager;
        _currentUserService = currentUserService;
        _addressService = addressService;
    }
    
    public async Task<AddressDto> Handle(GetUserAddressQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmaiWithAdressAsync(_currentUserService.User);
        
        // if user exists, find his address. Address repository
        var address = await _addressService.GetByIdAsync(user.Id);
        
        // if there is no address, create a new one
        if (address == null)
        {
            var createdAddress = await _addressService.CreateAsync(new Address() { AppUserId = user.Id });
            return createdAddress.ToDto();
        }
        
        return address.ToDto();
    }
}
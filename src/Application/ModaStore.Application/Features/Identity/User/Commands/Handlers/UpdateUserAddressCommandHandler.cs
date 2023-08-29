using MediatR;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.Extensions;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Identity.User.Commands.Models;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Interfaces.Customer.Management;
using ModaStore.Domain.Interfaces.Identity.Authentication;

namespace ModaStore.Application.Features.Identity.User.Commands.Handlers;

public class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommand, AddressDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICurrentUserService  _currentUserService;
    private readonly IAddressService _addressService;
    
    public UpdateUserAddressCommandHandler(UserManager<AppUser> userManager, ICurrentUserService currentUserService, IAddressService addressService)
    {
        _userManager = userManager;
        _currentUserService = currentUserService;
        _addressService = addressService;
    }
    
    
    public async Task<AddressDto> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmaiWithAdressAsync(_currentUserService.User);
        
        user.Address = request.Address.ToEntity();
        
        var result = await _userManager.UpdateAsync(user);
        
        if (result.Succeeded)
        {
            return user.Address.ToDto();
        }
        
        throw new Exception("Problem saving changes");
        
        
    }
}
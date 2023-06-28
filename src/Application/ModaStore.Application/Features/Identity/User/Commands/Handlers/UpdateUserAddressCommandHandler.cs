using MediatR;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.Extensions;
using ModaStore.Application.Features.Identity.User.Commands.Models;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Interfaces.Identity.Authentication;

namespace ModaStore.Application.Features.Identity.User.Commands.Handlers;

// public class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommand, AddressDto>
// {
//     private readonly UserManager<AppUser> _userManager;
//     private readonly ICurrentUserService  _currentUserService;
//     
//     
//     public async Task<AddressDto> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
//     {
//         // var user = await _userManager.FindByEmaiWithAdressAsync(_currentUserService.User);
//         //
//         // user.Address = request.Address.ToEntity();
//         // var res = request.Address;
//         //
//         //
//         //
//         // var result = await _userManager.UpdateAsync(user);
//         //
//         // if (result.Succeeded) return result.
//         //
//         // throw new Exception("Problem updating user address");
//         
//         
//     }
// }
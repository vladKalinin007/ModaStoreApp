using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.Extensions;
using ModaStore.Application.Features.Identity.User.Queries.Models;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Interfaces.Identity.Authentication;

namespace ModaStore.Application.Features.Identity.User.Queries.Handlers;

// public class GetUserAddressQueryHandler : IRequestHandler<GetUserAddressQuery, AddressDto>
// {
//     private readonly UserManager<AppUser> _userManager;
//     private readonly ICurrentUserService  _currentUserService;
//         
//     public GetUserAddressQueryHandler(UserManager<AppUser> userManager, ICurrentUserService currentUserService)
//     {
//         _userManager = userManager;
//         _currentUserService = currentUserService;
//     }
//     
//     public async Task<AddressDto> Handle(GetUserAddressQuery request, CancellationToken cancellationToken)
//     {
//         var user = await _userManager.FindByEmaiWithAdressAsync(_currentUserService.User);
//         
//         if (user == null)
//         {
//             
//         }
//         
//         return user.Address.ToDto();
//     }
// }
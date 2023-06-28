using MediatR;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.DTOs.Identity;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Identity.User.Commands.Models;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Interfaces.Identity.UserManagement;

namespace ModaStore.Application.Features.Identity.User.Commands.Handlers;

// public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserDto>
// {
//     private readonly UserManager<AppUser> _userManager;
//     
//     
//     public AddUserCommandHandler(UserManager<AppUser> userManager)
//     {
//         _userManager = userManager;
//     }
//
//     public async Task<UserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
//     {
//         var user = request.Model.ToEntity();
//         
//         await _userManager.CreateAsync(user, request.Model.);
//         
//         return user.ToDto();
//     }
// }
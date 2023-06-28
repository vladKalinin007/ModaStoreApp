using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.DTOs.Identity;
using ModaStore.Application.Extensions;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Identity.Authentication.Commands.Models;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Interfaces.Authentication.Security;

namespace ModaStore.Application.Features.Identity.Authentication.Commands.Handlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, UserDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;

    public RegisterCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }


    public async Task<UserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = request.Model.ToEntity();
        
        var password = request.Model.Password;
        
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            
        }

        return user
            .ToDto()
            .AddToken(_tokenService, user);


    }
}

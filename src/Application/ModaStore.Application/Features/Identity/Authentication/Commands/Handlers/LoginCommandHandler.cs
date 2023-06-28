using MediatR;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.DTOs.Identity;
using ModaStore.Application.Extensions;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Identity.Authentication.Commands.Models;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Interfaces.Authentication.Security;

namespace ModaStore.Application.Features.Identity.Authentication.Commands.Handlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, UserDto>
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    
    public LoginCommandHandler(SignInManager<AppUser> signInManager, ITokenService tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<UserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var email = request.Model.Email;
        var passwrod = request.Model.Password;
        var user = await _signInManager.UserManager.FindByEmailAsync(email);
        
        var result = await _signInManager.CheckPasswordSignInAsync(user, passwrod, false);
        
        if (!result.Succeeded) return null;
        
        return user
            .ToDto()
            .AddToken(_tokenService, user);
    }
}
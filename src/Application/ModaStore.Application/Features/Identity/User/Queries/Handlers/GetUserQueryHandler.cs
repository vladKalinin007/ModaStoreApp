using MediatR;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.DTOs.Identity;
using ModaStore.Application.Extensions;
using ModaStore.Application.Features.Identity.User.Queries.Models;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Interfaces.Authentication.Security;
using ModaStore.Domain.Interfaces.Identity.Authentication;

namespace ModaStore.Application.Features.Identity.User.Queries.Handlers;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICurrentUserService  _currentUserService;
    private readonly ITokenService _tokenService;
    
    public GetUserQueryHandler(
        UserManager<AppUser> userManager, 
        ICurrentUserService currentUserService,
        ITokenService tokenService
        )
    {
        _userManager = userManager;
        _currentUserService = currentUserService;
        _tokenService = tokenService;
    }
    
    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailFromClaimsPrincipal(_currentUserService.User);
        
        return new UserDto
        {
            DisplayName = user.DisplayName,
            Email = user.Email,
            Token = _tokenService.CreateToken(user)
        };
    }
}
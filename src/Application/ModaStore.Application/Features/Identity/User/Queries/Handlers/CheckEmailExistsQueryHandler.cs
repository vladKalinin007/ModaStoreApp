using MediatR;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.Features.Identity.User.Queries.Models;
using ModaStore.Domain.Entities.Identity;

namespace ModaStore.Application.Features.Identity.User.Queries.Handlers;

public class CheckEmailExistsQueryHandler : IRequestHandler<CheckEmailExistsQuery, bool>
{
    private readonly UserManager<AppUser> _userManager;
    
    public CheckEmailExistsQueryHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<bool> Handle(CheckEmailExistsQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.FindByEmailAsync(request.Email) != null;
    }
}
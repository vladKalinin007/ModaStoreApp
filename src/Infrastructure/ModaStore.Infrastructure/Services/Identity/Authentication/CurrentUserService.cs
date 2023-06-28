using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ModaStore.Domain.Interfaces.Identity.Authentication;

namespace ModaStore.Infrastructure.Services.Identity.Authentication;

public class CurrentUserService : ICurrentUserService
{
    public ClaimsPrincipal User => HttpContextAccessor.HttpContext.User;

    private readonly IHttpContextAccessor HttpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        HttpContextAccessor = httpContextAccessor;
    }
}

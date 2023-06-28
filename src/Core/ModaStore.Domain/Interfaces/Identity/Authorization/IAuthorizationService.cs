namespace ModaStore.Domain.Interfaces.Identity.Authorization;

public interface IAuthorizationService
{
    Task<bool> AuthorizeAsync(string username, string resource);
    Task<bool> CheckAccessAsync(string username, string resource, string action);
    Task<bool> AddPermissionAsync(string username, string resource, string action);
    Task<bool> RemovePermissionAsync(string username, string resource, string action);
}

namespace ModaStore.Domain.Interfaces.Identity.Permissions;

public interface IPermissionService
{
    bool Authorize(string permissionSystemName);
    bool AuthorizeAction(string permissionSystemName, string permissionActionName);
}

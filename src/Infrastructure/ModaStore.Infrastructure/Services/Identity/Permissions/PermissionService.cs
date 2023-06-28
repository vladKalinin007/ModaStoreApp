using ModaStore.Domain.Interfaces.Identity.Permissions;

namespace ModaStore.Infrastructure.Services.Identity.Permissions;

public class PermissionService : IPermissionService
{
    public bool Authorize(string permissionSystemName)
    {
        // Логика проверки разрешения
        return true; // Здесь должна быть реализация проверки разрешения
    }

    public bool AuthorizeAction(string permissionSystemName, string permissionActionName)
    {
        // Логика проверки разрешения для действия
        return true; // Здесь должна быть реализация проверки разрешения для действия
    }
}
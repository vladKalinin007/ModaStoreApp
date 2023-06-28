using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Identity.Permissions;

public class PermissionAction : BaseEntity
{

    /// <summary>
    /// Gets or sets the permission system name
    /// </summary>
    public string SystemName { get; set; }

    /// <summary>
    /// Gets or sets the customer group ident
    /// </summary>
    public string CustomerGroupId { get; set; }

    /// <summary>
    /// Gets or sets the action name for denied access
    /// </summary>
    public string Action { get; set; }

}
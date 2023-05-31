namespace ModaStore.Domain.Permissions;

public interface IGroupLinkEntity
{
    /// <summary>
    /// Gets or sets a value indicating whether the entity is subject to group
    /// </summary>
    bool LimitedToGroups { get; set; }
    IList<string> CustomerGroups { get; set; }
}
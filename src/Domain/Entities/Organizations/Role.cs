using Domain.Common;

namespace Domain.Entities.Organizations;

public class Role : BaseAuditableEntity
{
    public required string Name { get; init; }

    public virtual ICollection<UserInRole> UserInRoles { get; init; } = new List<UserInRole>();

    public virtual ICollection<RoleInGroup> RoleInGroups { get; init; } = new List<RoleInGroup>();
}
using Domain.Common;

namespace Domain.Entities.Organizations;

public class Group : BaseAuditableEntity
{
    public required string Name { get; init; }

    public virtual ICollection<UserInGroup> UserInGroups { get; init; } = new List<UserInGroup>();

    public virtual ICollection<RoleInGroup> RoleInGroups { get; init; } = new List<RoleInGroup>();
}
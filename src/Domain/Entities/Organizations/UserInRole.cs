using Domain.Common;

namespace Domain.Entities.Organizations;

public class UserInRole : BaseAuditableEntity
{
    public Guid UserId { get; init; }

    public Guid RoleId { get; init; }

    public virtual User User { get; init; } = null!;

    public virtual Role Role { get; init; } = null!;
}
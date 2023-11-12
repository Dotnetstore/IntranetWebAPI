using Domain.Common;

namespace Domain.Entities.Organizations;

public class UserInGroup : BaseAuditableEntity
{
    public Guid UserId { get; init; }

    public Guid GroupId { get; init; }

    public virtual User User { get; init; } = null!;

    public virtual Group Group { get; init; } = null!;
}
using Domain.Common;

namespace Domain.Entities.Organizations;

public class User : UserIdentity
{
    public Guid CompanyId { get; init; }

    public virtual OwnCompany OwnCompany { get; init; } = null!;

    public virtual ICollection<UserInRole> UserInRoles { get; init; } = new List<UserInRole>();

    public virtual ICollection<UserInGroup> UserInGroups { get; init; } = new List<UserInGroup>();
}
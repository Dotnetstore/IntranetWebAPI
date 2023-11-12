using Domain.Common;

namespace Domain.Entities.Organizations;

public class OwnCompany : Company
{
    public virtual ICollection<User> Users { get; init; } = new List<User>();
}
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Validations;

namespace Domain.Entities.Organizations;

[Table("User", Schema = "Organization")]
public class User : UserIdentity
{
    [RequiredGuid]
    public Guid CompanyId { get; init; }

    [ForeignKey(nameof(CompanyId))]
    public virtual OwnCompany OwnCompany { get; init; } = null!;

    public virtual ICollection<UserInRole> UserInRoles { get; init; } = new List<UserInRole>();

    public virtual ICollection<UserInGroup> UserInGroups { get; init; } = new List<UserInGroup>();
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Validations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Organizations;

[Table("UserInGroup", Schema = "Organization")]
[Index(nameof(UserId), IsUnique = false)]
[Index(nameof(GroupId), IsUnique = false)]
public class UserInGroup : BaseAuditableEntity
{
    [Required]
    [RequiredGuid]
    public Guid UserId { get; init; }

    [Required]
    [RequiredGuid]
    public Guid GroupId { get; init; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; init; } = null!;

    [ForeignKey(nameof(GroupId))]
    public virtual Group Group { get; init; } = null!;
}
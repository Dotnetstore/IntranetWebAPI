using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Validations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Organizations;

[Table("UserInRole", Schema = "Organization")]
[Index(nameof(UserId), IsUnique = false)]
[Index(nameof(RoleId), IsUnique = false)]
public class UserInRole : BaseAuditableEntity
{
    [Required]
    [RequiredGuid]
    public Guid UserId { get; init; }

    [Required]
    [RequiredGuid]
    public Guid RoleId { get; init; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; init; } = null!;

    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; init; } = null!;
}
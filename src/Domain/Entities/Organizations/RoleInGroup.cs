using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Validations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Organizations;

[Table("RoleInGroup", Schema = "Organization")]
[Index(nameof(GroupId), IsUnique = false)]
[Index(nameof(RoleId), IsUnique = false)]
public class RoleInGroup : BaseAuditableEntity
{
    [Required]
    [RequiredGuid]
    public Guid GroupId { get; init; }

    [Required]
    [RequiredGuid]
    public Guid RoleId { get; init; }

    [ForeignKey(nameof(GroupId))]
    public virtual Group Group { get; init; } = null!;

    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; init; } = null!;
}
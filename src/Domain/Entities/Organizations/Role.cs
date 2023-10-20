using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Organizations;

[Table("Role", Schema = "Organization")]
[Index(nameof(Name), IsUnique = true)]
public class Role : BaseAuditableEntity
{
    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    [StringLength(30, MinimumLength = 3)]
    [Column(TypeName = "varchar(30)")]
    public required string Name { get; init; }

    public virtual ICollection<UserInRole> UserInRoles { get; init; } = new List<UserInRole>();

    public virtual ICollection<RoleInGroup> RoleInGroups { get; init; } = new List<RoleInGroup>();
}
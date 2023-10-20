using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Contacts;

[Table("ContactInformation", Schema = "Contact")]
[Index(nameof(Text), IsUnique = false)]
public class ContactInformation : BaseAuditableEntity
{
    public ContactInformationType ContactInformationType { get; init; } = null!;

    [Required]
    [MinLength(3)]
    [MaxLength(255)]
    [StringLength(255, MinimumLength = 3)]
    [Column(TypeName = "varchar(255)")]
    public required string Text { get; init; }
}
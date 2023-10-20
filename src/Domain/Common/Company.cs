using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Validations;

namespace Domain.Common;

public abstract class Company : BaseAuditableEntity
{
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    [StringLength(100, MinimumLength = 1)]
    [Column(TypeName = "nvarchar(100)")]
    public required string Name { get; init; }

    [MinLength(0)]
    [MaxLength(30)]
    [StringLength(30, MinimumLength = 0)]
    [CorporateId]
    public string? CorporateId { get; init; }
}
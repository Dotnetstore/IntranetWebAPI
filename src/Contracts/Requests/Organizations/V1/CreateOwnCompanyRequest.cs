using System.ComponentModel.DataAnnotations;
using Domain.Validations;

namespace Contracts.Requests.Organizations.V1;

public record CreateOwnCompanyRequest
{
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    [StringLength(100, MinimumLength = 1)]
    public required string Name { get; init; }

    [MinLength(0)]
    [MaxLength(30)]
    [StringLength(30, MinimumLength = 0)]
    [CorporateId]
    public string? CorporateId { get; set; }

    [OptionalGuid]
    public Guid? UserId { get; set; }
}
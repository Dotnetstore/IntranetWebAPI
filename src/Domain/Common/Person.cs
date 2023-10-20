using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Validations;

namespace Domain.Common;

public abstract class Person : BaseAuditableEntity
{
    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "nvarchar(25)")]
    [StringLength(25, MinimumLength = 1)]
    [MinLength(1)]
    [MaxLength(25)]
    [DataType(DataType.Text)]
    public required string LastName { get; init; }

    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "nvarchar(25)")]
    [StringLength(25, MinimumLength = 1)]
    [MinLength(1)]
    [MaxLength(25)]
    [DataType(DataType.Text)]
    public required string FirstName { get; init; }

    [Column(TypeName = "nvarchar(25)")]
    [StringLength(25, MinimumLength = 0)]
    [MinLength(0)]
    [MaxLength(25)]
    [DataType(DataType.Text)]
    public string? MiddleName { get; init; }

    [Required]
    public bool LastNameFirst { get; init; }

    [Required]
    public bool IsMale { get; init; }

    [Column(TypeName = "varchar(20)")]
    [StringLength(20, MinimumLength = 0)]
    [MinLength(0)]
    [MaxLength(20)]
    [DataType(DataType.Text)]
    [SocialSecurityNumber]
    public string? SocialSecurityNumber { get; init; }

    [Column(TypeName = "nvarchar(25)")]
    [StringLength(25, MinimumLength = 1)]
    [MinLength(1)]
    [MaxLength(25)]
    [DataType(DataType.Text)]
    public string? EnglishName { get; init; }
}
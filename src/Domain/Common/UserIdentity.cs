using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;

public abstract class UserIdentity : Person
{
    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50, MinimumLength = 1)]
    [MinLength(1)]
    [MaxLength(50)]
    [DataType(DataType.Text)]
    public required string Username { get; init; }

    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "varchar(2000)")]
    [StringLength(2000, MinimumLength = 1)]
    [MinLength(1)]
    [MaxLength(2000)]
    [DataType(DataType.Password)]
    public required string Password { get; init; }

    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "varchar(100)")]
    [StringLength(100, MinimumLength = 50)]
    [MinLength(50)]
    [MaxLength(100)]
    [DataType(DataType.Password)]
    public required string Salt1 { get; init; }

    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "varchar(100)")]
    [StringLength(100, MinimumLength = 50)]
    [MinLength(50)]
    [MaxLength(100)]
    [DataType(DataType.Password)]
    public required string Salt2 { get; init; }

    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "varchar(100)")]
    [StringLength(100, MinimumLength = 50)]
    [MinLength(50)]
    [MaxLength(100)]
    [DataType(DataType.Password)]
    public required string Salt3 { get; init; }

    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "varchar(100)")]
    [StringLength(100, MinimumLength = 50)]
    [MinLength(50)]
    [MaxLength(100)]
    [DataType(DataType.Password)]
    public required string Salt4 { get; init; }

    [Required]
    public bool IsBlocked { get; init; }

    public DateTimeOffset? BlockedDate { get; init; }

    public DateTimeOffset? LastLoginDate { get; init; }
}
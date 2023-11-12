namespace Domain.Common;

public abstract class Company : BaseAuditableEntity
{
    public required string Name { get; init; }

    public string? CorporateId { get; init; }
}
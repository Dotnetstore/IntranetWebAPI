namespace Contracts.Dtos.Common;

public abstract record CompanyDto : BaseAuditableEntityDto
{
    public required string Name { get; init; }
    
    public string? CorporateId { get; init; }
}
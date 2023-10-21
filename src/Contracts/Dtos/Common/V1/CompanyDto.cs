namespace Contracts.Dtos.Common.V1;

public abstract record CompanyDto : BaseAuditableEntityDto
{
    public required string Name { get; init; }
    
    public string? CorporateId { get; init; }
}
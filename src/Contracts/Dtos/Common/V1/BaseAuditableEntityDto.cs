namespace Contracts.Dtos.Common.V1;

public abstract record BaseAuditableEntityDto : BaseEntityDto
{
    public Guid? CreatedBy { get; init; }

    public DateTimeOffset CreatedDate { get; init; }

    public Guid? LastUpdatedBy { get; init; }

    public DateTimeOffset? LastUpdatedDate { get; init; }

    public bool IsDeleted { get; init; }

    public Guid? DeletedBy { get; init; }

    public DateTimeOffset? DeletedDate { get; init; }

    public bool IsSystem { get; init; }

    public bool IsGdpr { get; init; }
}
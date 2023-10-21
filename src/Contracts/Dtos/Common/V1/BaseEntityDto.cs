namespace Contracts.Dtos.Common.V1;

public abstract record BaseEntityDto
{
    public Guid Id { get; init; }
}
namespace Contracts.Dtos.Common;

public abstract record BaseEntityDto
{
    public Guid Id { get; init; }
}
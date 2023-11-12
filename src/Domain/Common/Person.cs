namespace Domain.Common;

public abstract class Person : BaseAuditableEntity
{
    public required string LastName { get; init; }

    public required string FirstName { get; init; }

    public string? MiddleName { get; init; }

    public bool LastNameFirst { get; init; }

    public bool IsMale { get; init; }

    public string? SocialSecurityNumber { get; init; }

    public string? EnglishName { get; init; }
}
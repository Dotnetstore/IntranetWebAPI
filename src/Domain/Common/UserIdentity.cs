namespace Domain.Common;

public abstract class UserIdentity : Person
{
    public required string Username { get; init; }

    public required string Password { get; init; }

    public required string Salt1 { get; init; }

    public required string Salt2 { get; init; }

    public required string Salt3 { get; init; }

    public required string Salt4 { get; init; }

    public bool IsBlocked { get; init; }

    public DateTimeOffset? BlockedDate { get; init; }

    public DateTimeOffset? LastLoginDate { get; init; }
}
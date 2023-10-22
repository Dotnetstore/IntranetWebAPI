namespace Contracts.Responses.Common.V1;

public class ValidationResponse
{
    public required string PropertyName { get; init; }

    public required string Message { get; init; }
}
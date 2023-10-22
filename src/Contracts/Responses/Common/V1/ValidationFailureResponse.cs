namespace Contracts.Responses.Common.V1;

public class ValidationFailureResponse
{
    public required IEnumerable<ValidationResponse> Errors { get; init; }
}
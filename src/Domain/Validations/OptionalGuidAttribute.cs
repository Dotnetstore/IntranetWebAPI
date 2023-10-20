using System.ComponentModel.DataAnnotations;

namespace Domain.Validations;

public sealed class OptionalGuidAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null)
            return true;

        var success = Guid.TryParse(value.ToString(), out var validGuid);

        if (!success)
            return false;

        return validGuid != Guid.Empty;
    }
}
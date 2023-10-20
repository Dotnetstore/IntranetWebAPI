using System.ComponentModel.DataAnnotations;
using Domain.Validations.CorporateId;

namespace Domain.Validations;

public sealed class CorporateIdAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null)
            return true;

        var valueAsString = value as string;

        if (string.IsNullOrEmpty(valueAsString))
            return true;

        valueAsString = valueAsString.Trim().ToUpper();

        if (valueAsString[..2] == "SE")
            return IsValidSwedishCorporateId(valueAsString);

        return false;
    }

    private static bool IsValidSwedishCorporateId(string value)
    {
        return CorporateIdSweden.Valid(value);
    }
}
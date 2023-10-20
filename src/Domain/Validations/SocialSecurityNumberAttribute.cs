using System.ComponentModel.DataAnnotations;
using Domain.Validations.SocialSecurityNumber;

namespace Domain.Validations;

public class SocialSecurityNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null)
            return true;

        var valueAsString = value as string;

        if (string.IsNullOrEmpty(valueAsString))
            return false;

        valueAsString = valueAsString.Trim();

        return SocialSecurityNumberSweden.Valid(valueAsString);
    }
}
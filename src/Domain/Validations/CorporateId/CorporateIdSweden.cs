using System.Text.RegularExpressions;
using Domain.Exceptions;
using Domain.Validations.SocialSecurityNumber;

namespace Domain.Validations.CorporateId;

public class CorporateIdSweden
{
    private static readonly string[] SwedishCorporateTypes =
    {
        "Okänt", // 0
        "Dödsbon", // 1
        "Stat, landsting, kommun eller församling", // 2
        "Utländska företag som bedriver näringsverksamhet eller äger fastigheter i Sverige", // 3
        "Okänt", // 4
        "Aktiebolag", // 5
        "Enkelt bolag", // 6
        "Ekonomisk förening eller bostadsrättsförening", // 7
        "Ideella förening och stiftelse", // 8
        "Handelsbolag, kommanditbolag och enkelt bolag", // 9
        "Enskild firma", // 10
    };

    private static readonly Regex Regex = new(@"^(\d{2}){0,1}(\d{2})(\d{2})(\d{2})([-+]?)?(\d{4})$");

    public static CorporateIdSweden Parse(string value) => new(value);

    public static bool TryParse(string value, out CorporateIdSweden? result)
    {
        try
        {
            result = new CorporateIdSweden(value);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

    public static bool Valid(string number)
    {
        try
        {
            Parse(number);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private string? _value;
    private SocialSecurityNumberSweden? _swedishSocialSecurityNumber;

    public string VatNumber => $"SE{ShortString}01";

    public bool IsSwedishSocialSecurityNumber => _swedishSocialSecurityNumber != null;

    public SocialSecurityNumberSweden? SwedishSocialSecurityNumber => _swedishSocialSecurityNumber;

    public string Type =>
        IsSwedishSocialSecurityNumber
            ? SwedishCorporateTypes[10]
            : SwedishCorporateTypes[int.Parse(_value![..1])];

    public CorporateIdSweden(string value)
    {
        InnerParse(value);
    }

    public string Format(bool separator = true)
    {
        var num = ShortString;
        return separator ? $"{num![..6]}-{num![6..]}" : num!;
    }

    private string ShortString => ((IsSwedishSocialSecurityNumber ? _swedishSocialSecurityNumber!.Format() : _value)!)
        .Replace("-", "")
        .Replace("+", "");

    private void InnerParse(string input)
    {
        var countryCode = input[..2];

        if (countryCode.ToUpper() != "SE")
            throw new SwedishCorporateNumberException("Must start with country code (SE)");

        var corporateId = input[2..];
        
        if (corporateId.Length is > 13 or < 10)
        {
            var state = corporateId.Length > 13 ? "long" : "short";
            throw new SwedishCorporateNumberException($"Input value too ${state}");
        }

        try
        {
            var matches = Regex.Matches(corporateId);
            if (matches.Count < 1 || matches[0].Groups.Count < 7)
            {
                throw new SwedishCorporateNumberException();
            }

            corporateId = corporateId.Replace("-", "")
                .Replace("+", "");
            // Get regexp match
            //var matches = regex.Matches(input);
            var groups = matches[0].Groups;

            // if [1] is set, it may only be prefixed with 16.
            if (!string.IsNullOrEmpty(groups[1].Value))
            {
                if (int.Parse(groups[1].Value) != 16)
                {
                    throw new SwedishCorporateNumberException();
                }

                corporateId = corporateId[2..];
            }

            // Third digit must be more than 20. Second digit must be more than 10.
            if (int.Parse(groups[3].Value) < 20 ||
                int.Parse(groups[2].Value) < 10 ||
                !LuhnAlgorithm.ValidateCheckDigit(corporateId))
            {
                throw new SwedishCorporateNumberException();
            }

            _value = corporateId;
        }
        catch (Exception ex)
        {
            try
            {
                _swedishSocialSecurityNumber = SocialSecurityNumberSweden.Parse(input);
            }
            catch
            {
                throw ex;
            }
        }
    }
}
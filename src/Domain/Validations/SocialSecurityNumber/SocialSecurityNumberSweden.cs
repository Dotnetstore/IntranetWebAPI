using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Domain.Exceptions;

namespace Domain.Validations.SocialSecurityNumber;

public class SocialSecurityNumberSweden
{
    public struct Options
    {
        public Options()
        {
            AllowInterimNumber = false;
            AllowCoordinationNumber = true;
        }

        public bool AllowCoordinationNumber { get; set; } = true;

        public bool AllowInterimNumber { get; set; } = false;
    }
    
    private static readonly Regex SsnRegex = new(@"^(?'century'\d{2}){0,1}(?'decade'\d{2})(?'month'\d{2})(?'day'\d{2})(?'separator'[\+\-]?)(?'numbers'((?!000)\d{3}|[TRSUWXJKLMN]\d{2}))(?'control'\d)$");
    private const string InterimTest = "(?![-+])\\D";

    public DateTime Date { get; }

    public int Age => GetDifferenceInYears(Date, DateTime.Now);

    public string Separator => Age >= 100 ? "+" : "-";

    public string Century { get; }

    public string FullYear { get; }

    public string Year { get; }

    public string Month { get; }

    public string Day { get; }

    public string Numbers { get; }

    public string ControlNumber { get; }

    public bool IsCoordinationNumber { get; set; }

    public bool IsMale { get; }

    public SocialSecurityNumberSweden(string ssn, Options? options = null)
    {
        options ??= new Options();

        var ssNumber = ValidateSsnString(ssn, options);
        var matches = GetMatchCollection(ssNumber);
        
        var groups = matches[0].Groups;
        var decade = groups["decade"].Value;
        var century = GetCentury(groups, decade);
        var day = GetDay(options, groups);
        
        var realDay = day;
        Century = century;
        Year = decade;
        FullYear = century + decade;
        Month = groups["month"].Value;
        Day = groups["day"].Value;
        Numbers = groups["numbers"].Value + groups["control"].Value;
        ControlNumber = groups["control"].Value;

        IsMale = int.Parse(Numbers[2].ToString()) % 2 == 1;
        
        if (!DateTime.TryParse($"{FullYear}-{Month:00}-{realDay:00}", out _))
        {
            throw new SwedishSocialSecurityNumberException("Invalid personal identity number.");
        }

        var num = groups["numbers"].Value;
        if (options.Value.AllowInterimNumber)
        {
            num = Regex.Replace(num, InterimTest, "1");
        }

        if (!LuhnAlgorithm.ValidateCheckDigit($"{Year}{Month}{Day}{Numbers}"))
        {
            throw new SwedishSocialSecurityNumberException("Invalid Luhn check number.");
        }

        Date = new DateTime(int.Parse($"{FullYear}"), int.Parse(Month), realDay, 0, 0, 0, DateTimeKind.Local);
    }

    public string Format(bool longFormat = false, bool ignoreSeparator = false)
    {
        return ignoreSeparator ? $"{(longFormat ? FullYear : Year)}{Month}{Day}{Numbers}" :
            $"{(longFormat ? FullYear : Year)}{Month}{Day}{Separator}{Numbers}";
    }

    public static SocialSecurityNumberSweden Parse(string ssn, Options? options = null)
    {
        return new SocialSecurityNumberSweden(ssn, options);
    }

    public static bool Valid(string ssn, Options? options = null)
    {
        options ??= new Options();

        try
        {
            Parse(ssn, options);
            return true;
        }
        catch (SwedishSocialSecurityNumberException)
        {
            return false;
        }
    }

    private int GetDay([DisallowNull] Options? options, GroupCollection groups)
    {
        var day = int.Parse(groups["day"].Value);
        if (options.Value.AllowCoordinationNumber)
        {
            IsCoordinationNumber = day > 60;
            day = IsCoordinationNumber ? day - 60 : day;
        }
        else if (day > 60)
        {
            throw new SwedishSocialSecurityNumberException("Invalid personal identity number.");
        }

        return day;
    }

    private static string GetCentury(GroupCollection groups, string decade)
    {
        string century;
        if (!string.IsNullOrEmpty(groups["century"].Value))
        {
            century = groups["century"].Value;
        }
        else
        {
            var born = DateTime.Now.Year - int.Parse(decade);
            if (groups["separator"].Value.Length != 0 &&
                groups["separator"].Value == "+")
            {
                born -= 100;
            }

            century = born.ToString()[..2];
        }

        return century;
    }

    private static MatchCollection GetMatchCollection(string ssn)
    {
        MatchCollection matches;

        try
        {
            matches = SsnRegex.Matches(ssn);

            if (matches.Count < 1 || matches[0].Groups.Count < 7)
            {
                throw new Exception("Invalid social security number"); // Just to enter the catch, as it is invalid.
            }
        }
        catch
        {
            throw new SwedishSocialSecurityNumberException("Failed to parse personal identity number. Invalid input.");
        }

        return matches;
    }

    private static string ValidateSsnString(string ssn, [DisallowNull] Options? options)
    {
        var countryString = ssn[..2];

        if (countryString.ToLower() != "se")
            throw new SwedishSocialSecurityNumberException("Social security number must start with country code (SE).");

        var ssNumber = ssn[2..];
        if (ssNumber.Length is > 13 or < 10)
        {
            var state = ssNumber.Length < 10 ? "short" : "long";
            throw new SwedishSocialSecurityNumberException($"Input string too {state}");
        }

        if (!options.Value.AllowInterimNumber && Regex.IsMatch(ssNumber.Trim(), InterimTest))
        {
            throw new SwedishSocialSecurityNumberException(
                $"{ssNumber} contains non-integer characters and options are set to not allow interim numbers"
            );
        }

        return ssNumber;
    }

    private static int GetDifferenceInYears(DateTime startDate, DateTime endDate)
    {
        var years = endDate.Year - startDate.Year;

        if (startDate.Month == endDate.Month &&
            endDate.Day < startDate.Day
            || endDate.Month < startDate.Month)
        {
            years--;
        }

        return years;
    }
}
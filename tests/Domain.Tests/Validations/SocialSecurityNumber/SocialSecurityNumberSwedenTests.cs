using Domain.Exceptions;
using Domain.Validations.SocialSecurityNumber;
using FluentAssertions;

namespace Domain.Tests.Validations.SocialSecurityNumber;

public class SocialSecurityNumberSwedenTests
{
    [Theory]
    [InlineData("7101263924", false)]
    [InlineData("197101263924", false)]
    [InlineData("SE7101263924", true)]
    [InlineData("SE197101263924", true)]
    [InlineData("SE7101263925", false)]
    [InlineData("SE197101263925", false)]
    [InlineData("SE71012639", false)]
    public void Should_return_expected_result(string ssn, bool expected)
    {
        SocialSecurityNumberSweden.Valid(ssn).Should().Be(expected);
    }

    [Theory]
    [InlineData("SE7101263924", "19")]
    [InlineData("SE1212112724", "20")]
    public void Should_return_correct_century(string ssn, string century)
    {
        var validSsn = new SocialSecurityNumberSweden(ssn);

        validSsn.Century.Should().Be(century);
    }

    [Theory]
    [InlineData("SE7101263924", "71")]
    [InlineData("SE1212112724", "12")]
    public void Should_return_correct_year(string ssn, string year)
    {
        var validSsn = new SocialSecurityNumberSweden(ssn);

        validSsn.Year.Should().Be(year);
    }

    [Theory]
    [InlineData("SE7101263924", "1971")]
    [InlineData("SE1212112724", "2012")]
    public void Should_return_correct_full_year(string ssn, string fullYear)
    {
        var validSsn = new SocialSecurityNumberSweden(ssn);

        validSsn.FullYear.Should().Be(fullYear);
    }

    [Theory]
    [InlineData("SE7101263924", "01")]
    [InlineData("SE1212112724", "12")]
    public void Should_return_correct_month(string ssn, string month)
    {
        var validSsn = new SocialSecurityNumberSweden(ssn);

        validSsn.Month.Should().Be(month);
    }

    [Theory]
    [InlineData("SE7101263924", "26")]
    [InlineData("SE1212112724", "11")]
    public void Should_return_correct_day(string ssn, string day)
    {
        var validSsn = new SocialSecurityNumberSweden(ssn);

        validSsn.Day.Should().Be(day);
    }

    [Theory]
    [InlineData("SE7101263924", "1971-01-26")]
    [InlineData("SE1212112724", "2012-12-11")]
    public void Should_return_correct_date(string ssn, string date)
    {
        var validSsn = new SocialSecurityNumberSweden(ssn);

        validSsn.Date.Should().Be(DateTime.Parse(date));
    }

    [Theory]
    [InlineData("SE7101263924", "3924")]
    [InlineData("SE1212112724", "2724")]
    public void Should_return_correct_numbers(string ssn, string numbers)
    {
        var validSsn = new SocialSecurityNumberSweden(ssn);

        validSsn.Numbers.Should().Be(numbers);
    }

    [Theory]
    [InlineData("SE7101263924", "4")]
    [InlineData("SE1212112724", "4")]
    public void Should_return_correct_control_number(string ssn, string number)
    {
        var validSsn = new SocialSecurityNumberSweden(ssn);

        validSsn.ControlNumber.Should().Be(number);
    }

    [Theory]
    [InlineData("SE7101263924", false)]
    [InlineData("SE1212112724", false)]
    public void Should_return_correct_isMale(string ssn, bool isMale)
    {
        var validSsn = new SocialSecurityNumberSweden(ssn);

        validSsn.IsMale.Should().Be(isMale);
    }

    [Theory]
    [InlineData("SE7101263924", "-")]
    [InlineData("SE1212112724", "-")]
    [InlineData("SE121211+2724", "+")]
    public void Should_return_correct_separator(string ssn, string separator)
    {
        var validSsn = new SocialSecurityNumberSweden(ssn);

        validSsn.Separator.Should().Be(separator);
    }

    [Theory]
    [InlineData("SE7101263924")]
    [InlineData("SE1212112724")]
    public void Should_return_correct_age(string ssn)
    {
        var validSsn = new SocialSecurityNumberSweden(ssn);

        var years = GetDifferenceInYears(validSsn.Date, DateTime.Now);

        validSsn.Age.Should().Be(years);
    }

    [Theory]
    [InlineData("SE7101263924", false)]
    [InlineData("SE1212112724", false)]
    public void Should_return_correct_isCoordinationNumber(string ssn, bool isCoordinationNumber)
    {
        var validSsn = new SocialSecurityNumberSweden(ssn);

        validSsn.IsCoordinationNumber.Should().Be(isCoordinationNumber);
    }

    [Theory]
    [InlineData("SE7100263924")]
    [InlineData("SE7101663924")]
    [InlineData("SE71016639B4")]
    public void Should_throw_swedishSocialSecurityNumberException(string ssn, bool allowCoordinationNumber = false)
    {
        var action = () => SocialSecurityNumberSweden.Parse(ssn, new SocialSecurityNumberSweden.Options{AllowCoordinationNumber = allowCoordinationNumber});

        action.Should().ThrowExactly<SwedishSocialSecurityNumberException>("Invalid personal identity number.");
    }

    [Theory]
    [InlineData("SE7101263924")]
    public void Should_return_valid_with_allowInterimNumber(string ssn)
    {
        var result = new SocialSecurityNumberSweden(ssn, new SocialSecurityNumberSweden.Options{AllowInterimNumber = true});

        result.Separator.Should().Be("-");
    }

    [Theory]
    [InlineData("SE7101263924", "710126-3924")]
    [InlineData("SE7101263924", "7101263924", false, true)]
    [InlineData("SE7101263924", "197101263924", true, true)]
    [InlineData("SE7101263924", "19710126-3924", true, false)]
    public void Should_return_correct_format(string ssn, string expected, bool longFormat = false, bool ignoreSeparator = false)
    {
        var result = new SocialSecurityNumberSweden(ssn);
        var format = result.Format(longFormat, ignoreSeparator);

        format.Should().Be(expected);
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
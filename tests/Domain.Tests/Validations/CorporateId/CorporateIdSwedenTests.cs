using Domain.Validations.CorporateId;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Domain.Tests.Validations.CorporateId;

public class CorporateIdSwedenTests
{
    [Theory]
    [InlineData("SE556056-6258", true)]
    [InlineData("SE5560566258", true)]
    [InlineData("5560566258", false)]
    [InlineData("SE556056625", false)]
    [InlineData("SE5518566258", false)]
    public void Should_return_expected(string corporateId, bool expected)
    {
        var isValid = CorporateIdSweden.Valid(corporateId);

        isValid.Should().Be(expected);
    }

    [Theory]
    [InlineData("SE5560566258", "556056-6258")]
    public void Should_return_correct_format(string corporateId, string expected)
    {
        var validator = CorporateIdSweden.Parse(corporateId);
        var format = validator.Format();

        format.Should().Be(expected);
    }

    [Theory]
    [InlineData("SE5560566258", true)]
    [InlineData("SE55605662m8", false)]
    public void TryParse_should_return_expected(string corporateId, bool expected)
    {
        var success = CorporateIdSweden.TryParse(corporateId, out CorporateIdSweden? result);

        using (new AssertionScope())
        {
            success.Should().Be(expected);

            if (success)
                result.Should().NotBeNull();
            else
                result.Should().BeNull();
        }
    }

    [Theory]
    [InlineData("SE5560566258", "SE556056625801")]
    public void VatNumber_should_return_expected(string corporateId, string expected)
    {
        var validator = new CorporateIdSweden(corporateId);
        var vatNumber = validator.VatNumber;

        vatNumber.Should().Be(expected);
    }

    [Theory]
    [InlineData("SE7101263924", true)]
    public void Should_return_Swedish_social_security_number(string corporateId, bool expected)
    {
        var validator = new CorporateIdSweden(corporateId);
        var result = validator.IsSwedishSocialSecurityNumber;

        using (new AssertionScope())
        {
            result.Should().Be(expected);
            validator.SwedishSocialSecurityNumber.Should().NotBeNull();
        }
    }

    [Theory]
    [InlineData("SE7101263924", "Enskild firma")]
    [InlineData("SE5560566258", "Aktiebolag")]
    public void Should_return_correct_type(string corporateId, string expected)
    {
        var validator = new CorporateIdSweden(corporateId);
        var result = validator.Type;

        result.Should().Be(expected);
    }
}
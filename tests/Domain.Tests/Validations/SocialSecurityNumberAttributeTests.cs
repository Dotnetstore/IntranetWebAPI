using Domain.Validations;
using Domain.Validations.SocialSecurityNumber;
using FluentAssertions;

namespace Domain.Tests.Validations;

public class SocialSecurityNumberAttributeTests
{
    [Theory]
    [InlineData(null, true)] // Null input should be considered valid
    [InlineData("", false)] // Empty string is not a valid SSN
    [InlineData("SE7101263924", true)] // Valid SSN
    [InlineData("SE197101263924", true)] // Valid SSN
    [InlineData("SE19710126-3924", true)] // Valid SSN
    [InlineData("SE710126-3924", true)] // Valid SSN
    [InlineData("123456789012", false)] // InValid SSN
    [InlineData("12345678901", false)] // Invalid, too short
    [InlineData("1234abcd56789012", false)] // Invalid, non-numeric characters
    [InlineData("123456789013", false)] // Invalid, contains a '3'
    public void IsValid_ShouldReturnCorrectResult(string inputValue, bool expectedResult)
    {
        // Arrange
        var attribute = new SocialSecurityNumberAttribute();

        // Act
        var isValid = attribute.IsValid(inputValue);

        // Assert
        expectedResult.Should().Be(isValid);
    }
    
    [Theory]
    [InlineData("SE197101263924", true)] // Valid SSN
    [InlineData("123456789013", false)] // Invalid SSN, contains a '3'
    [InlineData("123456789011", false)] // Invalid SSN, contains a '1'
    public void IsValidSwedishSocialSecurityNumber_ShouldReturnCorrectResult(string inputValue, bool expectedResult)
    {
        // Act
        var isValid = SocialSecurityNumberSweden.Valid(inputValue);

        // Assert
        expectedResult.Should().Be(isValid);
    }
}
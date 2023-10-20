using Domain.Validations;
using FluentAssertions;

namespace Domain.Tests.Validations;

public class LuhnAlgorithmTests
{
    [Theory]
    [InlineData("45320151128336", true)] // Valid credit card number
    [InlineData("6011000990139424", true)] // Valid credit card number
    [InlineData("79927398713", true)] // Valid IMEI number
    [InlineData("12345", false)] // Invalid, too short
    [InlineData("abcde", false)] // Invalid, non-numeric characters
    [InlineData("", false)] // Invalid, empty string
    [InlineData(null, false)] // Invalid, null input
    [InlineData("79927398714", false)] // Invalid check digit
    [InlineData("79927398711", false)] // Invalid check digit
    public void ValidateCheckDigit_ShouldReturnCorrectResult(string inputValue, bool expectedResult)
    {
        // Arrange & Act
        var isValid = LuhnAlgorithm.ValidateCheckDigit(inputValue);

        // Assert
        expectedResult.Should().Be(isValid);
    }
}
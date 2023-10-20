using Domain.Validations;
using FluentAssertions;

namespace Domain.Tests.Validations;

public class OptionalGuidAttributeTests
{
    [Theory]
    [InlineData(null, true)] // Null input should be considered valid
    [InlineData("", false)] // Empty string is not a valid Guid
    [InlineData("invalidGuid", false)] // Invalid format is not a valid Guid
    [InlineData("12345678-1234-1234-1234-123456789012", true)] // Valid Guid
    [InlineData("00000000-0000-0000-0000-000000000000", false)] // Empty Guid is not valid
    public void IsValid_ShouldReturnCorrectResult(string inputValue, bool expectedResult)
    {
        // Arrange
        var attribute = new OptionalGuidAttribute();

        // Act
        var isValid = attribute.IsValid(inputValue);

        // Assert
        expectedResult.Should().Be(isValid);
    }
}
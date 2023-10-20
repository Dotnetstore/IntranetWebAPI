using Domain.Validations;
using FluentAssertions;

namespace Domain.Tests.Validations;

public class CorporateIdAttributeTests
{
    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData("SE1234567890", false)]
    [InlineData("SE12345678901", false)]
    [InlineData("DE1234567890", false)]
    [InlineData("SEABCDE7890", false)]
    [InlineData("SE5560566258", true)]
    [InlineData("SE556056-6258", true)]
    public void IsValid_ShouldReturnCorrectResult(string inputValue, bool expectedIsValid)
    {
        // Arrange
        var attribute = new CorporateIdAttribute();

        // Act
        var isValid = attribute.IsValid(inputValue);

        // Assert
        expectedIsValid.Should().Be(isValid);
    }
}
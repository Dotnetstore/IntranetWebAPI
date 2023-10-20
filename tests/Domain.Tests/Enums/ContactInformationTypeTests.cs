using Domain.Enums;
using Domain.Resources;
using FluentAssertions;

namespace Domain.Tests.Enums;

public class ContactInformationTypeTests
{
    [Fact]
    public void RegisterEmailAddressTypeShouldHaveCorrectGuid()
    {
        // Arrange
        var type = ContactInformationType.RegisterEmailAddress;

        // Act
        var expectedGuid = new Guid("2899BED0-BC4D-4773-9279-493D9C17A033");

        // Assert
        expectedGuid.Should().Be(type.Value);
    }
    
    [Fact]
    public void RegisterEmailAddressTypeShouldHaveCorrectName()
    {
        // Arrange
        var type = ContactInformationType.RegisterEmailAddress;

        // Act
        const string expectedName = "RegisterEmailAddress";

        // Assert
        expectedName.Should().Be(type.Name);
    }
    
    [Fact]
    public void RegisterEmailAddressTypeShouldHaveCorrectText()
    {
        // Arrange
        var type = ContactInformationType.RegisterEmailAddress;

        // Act
        var expectedText = ContactInformationTypeText.RegisterEmailAddress;

        // Assert
        expectedText.Should().Be(type.Text);
    }
}
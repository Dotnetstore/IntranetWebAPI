using Domain.Enums;
using Domain.Resources;
using FluentAssertions;

namespace Domain.Tests.Enums;

public class EmailTypeTests
{
    [Fact]
    public void RegisterEmailAddressTypeShouldHaveCorrectGuid()
    {
        // Arrange
        var type = EmailType.RegistrationEmail;

        // Act
        var expectedGuid = new Guid("2899BED0-BC4D-4773-9279-493D9C17A033");

        // Assert
        expectedGuid.Should().Be(type.Value);
    }
    
    [Fact]
    public void RegisterEmailAddressTypeShouldHaveCorrectName()
    {
        // Arrange
        var type = EmailType.RegistrationEmail;

        // Act
        const string expectedName = "RegistrationEmail";

        // Assert
        expectedName.Should().Be(type.Name);
    }
    
    [Fact]
    public void RegisterEmailAddressTypeShouldHaveCorrectText()
    {
        // Arrange
        var type = EmailType.RegistrationEmail;

        // Act
        var expectedText = ContactInformationTypeText.RegistrationEmailAddress;

        // Assert
        expectedText.Should().Be(type.Text);
    }
}
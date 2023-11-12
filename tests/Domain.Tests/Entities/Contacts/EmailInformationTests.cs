using Domain.Entities.Contacts;
using Domain.Enums;
using FluentAssertions;

namespace Domain.Tests.Entities.Contacts;

public class EmailInformationTests
{
    private readonly EmailInformation _testObject = new()
    {
        EmailType = EmailType.RegistrationEmail,
        Text = "Test"
    };

    [Fact]
    public void Should_contain_contactInformationType()
    {
        _testObject.EmailType.Should().Be(EmailType.RegistrationEmail);
    }

    [Fact]
    public void Should_contain_text()
    {
        _testObject.Text.Should().Be("Test");
    }
}
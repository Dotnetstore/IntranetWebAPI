using Domain.Entities.Contacts;
using Domain.Enums;
using FluentAssertions;

namespace Domain.Tests.Entities.Contacts;

public class ContactInformationTests
{
    private readonly ContactInformation _testObject = new()
    {
        ContactInformationType = ContactInformationType.RegisterEmailAddress,
        Text = "Test"
    };

    [Fact]
    public void Should_contain_contactInformationType()
    {
        _testObject.ContactInformationType.Should().Be(ContactInformationType.RegisterEmailAddress);
    }

    [Fact]
    public void Should_contain_text()
    {
        _testObject.Text.Should().Be("Test");
    }
}
using Domain.Common;
using FluentAssertions;

namespace Domain.Tests.Common;

public class PersonTests
{
    private TestPerson _testObject = null!;

    [Fact]
    public void Should_contain_lastName()
    {
        const string name = "Test";
        _testObject = new TestPerson() { LastName = name, FirstName = name };

        _testObject.LastName.Should().Be(name);
    }

    [Fact]
    public void Should_contain_firstName()
    {
        const string name = "Test";
        _testObject = new TestPerson() { LastName = name, FirstName = name };

        _testObject.FirstName.Should().Be(name);
    }

    [Fact]
    public void Should_contain_middleName()
    {
        const string name = "Test";
        _testObject = new TestPerson() { LastName = name, FirstName = name, MiddleName = name};

        _testObject.MiddleName.Should().Be(name);
    }

    [Fact]
    public void Should_contain_lastNameFist()
    {
        const string name = "Test";
        const bool lastNameFirst = true;
        _testObject = new TestPerson() { LastName = name, FirstName = name, LastNameFirst = lastNameFirst};

        _testObject.LastNameFirst.Should().Be(lastNameFirst);
    }

    [Fact]
    public void Should_contain_isMale()
    {
        const string name = "Test";
        const bool isMale = true;
        _testObject = new TestPerson() { LastName = name, FirstName = name, IsMale = isMale};

        _testObject.IsMale.Should().Be(isMale);
    }

    [Fact]
    public void Should_contain_socialSecurityNumber()
    {
        const string name = "Test";
        _testObject = new TestPerson() { LastName = name, FirstName = name, SocialSecurityNumber = name};

        _testObject.SocialSecurityNumber.Should().Be(name);
    }

    [Fact]
    public void Should_contain_englishName()
    {
        const string name = "Test";
        _testObject = new TestPerson() { LastName = name, FirstName = name, EnglishName = name};

        _testObject.EnglishName.Should().Be(name);
    }
}

public class TestPerson : Person{}
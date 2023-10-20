using Domain.Common;
using FluentAssertions;

namespace Domain.Tests.Common;

public class UserIdentityTests
{
    private readonly TestUserIdentity _testObject;
    private readonly DateTimeOffset _date = new(2020, 1, 1, 1, 1, 1, new TimeSpan(0, 0, 60, 0));

    public UserIdentityTests()
    {
        _testObject = new TestUserIdentity
        {
            LastName = "Test",
            FirstName = "Test",
            Username = "Username",
            Password = "Password",
            BlockedDate = _date,
            IsBlocked = true,
            Salt1 = "Salt",
            Salt2 = "Salt",
            Salt3 = "Salt",
            Salt4 = "Salt",
            LastLoginDate = _date
        };
    }

    [Fact]
    public void Should_contain_userName()
    {
        _testObject.Username.Should().Be("Username");
    }

    [Fact]
    public void Should_contain_password()
    {
        _testObject.Password.Should().Be("Password");
    }

    [Fact]
    public void Should_contain_salt1()
    {
        _testObject.Salt1.Should().Be("Salt");
    }

    [Fact]
    public void Should_contain_salt2()
    {
        _testObject.Salt2.Should().Be("Salt");
    }

    [Fact]
    public void Should_contain_salt3()
    {
        _testObject.Salt3.Should().Be("Salt");
    }

    [Fact]
    public void Should_contain_salt4()
    {
        _testObject.Salt4.Should().Be("Salt");
    }

    [Fact]
    public void Should_contain_isBlocked()
    {
        _testObject.IsBlocked.Should().BeTrue();
    }

    [Fact]
    public void Should_contain_blockedDate()
    {
        _testObject.BlockedDate.Should().Be(_date);
    }

    [Fact]
    public void Should_contain_lastLoginDate()
    {
        _testObject.LastLoginDate.Should().Be(_date);
    }
}

public class TestUserIdentity : UserIdentity{}
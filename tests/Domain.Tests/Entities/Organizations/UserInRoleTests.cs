using Domain.Entities.Organizations;
using FluentAssertions;

namespace Domain.Tests.Entities.Organizations;

public class UserInRoleTests
{
    private readonly UserInRole _userInRole = new()
    {
        UserId = Guid.NewGuid(),
        RoleId = Guid.NewGuid(),
        User = new User
        {
            LastName = "Test",
            FirstName = "Test",
            Username = "Test",
            Password = "Test",
            Salt1 = "Test",
            Salt2 = "Test",
            Salt3 = "Test",
            Salt4 = "Test"
        },
        Role = new Role { Name = "Test" }
    };

    [Fact]
    public void Should_contain_userId()
    {
        _userInRole.UserId.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_contain_roleId()
    {
        _userInRole.RoleId.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_contain_user()
    {
        _userInRole.User.Should().NotBeNull();
    }

    [Fact]
    public void Should_contain_role()
    {
        _userInRole.Role.Should().NotBeNull();
    }
}
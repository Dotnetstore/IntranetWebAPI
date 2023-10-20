using Domain.Entities.Organizations;
using FluentAssertions;

namespace Domain.Tests.Entities.Organizations;

public class RoleTests
{
    private Role _role = new()
    {
        Name = "Test",
        UserInRoles = new List<UserInRole>(),
        RoleInGroups = new List<RoleInGroup>()
    };

    [Fact]
    public void Should_contain_name()
    {
        _role.Name.Should().Be("Test");
    }

    [Fact]
    public void Should_contain_userInRoles()
    {
        _role.UserInRoles.Should().BeEmpty();
    }

    [Fact]
    public void Should_contain_roleInGroups()
    {
        _role.RoleInGroups.Should().BeEmpty();
    }
}
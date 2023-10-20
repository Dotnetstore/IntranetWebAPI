using Domain.Entities.Organizations;
using FluentAssertions;

namespace Domain.Tests.Entities.Organizations;

public class RoleInGroupTests
{
    private readonly RoleInGroup _roleInGroup = new()
    {
        GroupId = Guid.NewGuid(),
        RoleId = Guid.NewGuid(),
        Group = new Group { Name = "Test" },
        Role = new Role { Name = "Test" }
    };

    [Fact]
    public void Should_contain_groupId()
    {
        _roleInGroup.GroupId.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_contain_roleId()
    {
        _roleInGroup.RoleId.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_contain_role()
    {
        _roleInGroup.Role.Should().NotBeNull();
    }

    [Fact]
    public void Should_contain_group()
    {
        _roleInGroup.Group.Should().NotBeNull();
    }
}
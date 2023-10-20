using Domain.Entities.Organizations;
using FluentAssertions;

namespace Domain.Tests.Entities.Organizations;

public class GroupTests
{
    private readonly Group _group = new()
    {
        Name = "Test",
        RoleInGroups = new List<RoleInGroup>(),
        UserInGroups = new List<UserInGroup>()
    };

    [Fact]
    public void Should_contain_name()
    {
        _group.Name.Should().Be("Test");
    }

    [Fact]
    public void Should_contain_roleInGroups()
    {
        _group.RoleInGroups.Should().BeEmpty();
    }

    [Fact]
    public void Should_contain_userInGroups()
    {
        _group.UserInGroups.Should().BeEmpty();
    }
}
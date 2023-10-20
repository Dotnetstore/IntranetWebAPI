using Domain.Entities.Organizations;
using FluentAssertions;

namespace Domain.Tests.Entities.Organizations;

public class UserInGroupTests
{
    private readonly UserInGroup _userInGroup = new()
    {
        UserId = Guid.NewGuid(),
        GroupId = Guid.NewGuid(),
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
        Group = new Group { Name = "Test" }
    };

    [Fact]
    public void Should_contain_userId()
    {
        _userInGroup.UserId.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_contain_groupId()
    {
        _userInGroup.GroupId.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_contain_user()
    {
        _userInGroup.User.Should().NotBeNull();
    }

    [Fact]
    public void Should_contain_group()
    {
        _userInGroup.Group.Should().NotBeNull();
    }
}
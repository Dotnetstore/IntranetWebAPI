using Domain.Entities.Organizations;
using FluentAssertions;

namespace Domain.Tests.Entities.Organizations;

public class UserTests
{
    private readonly User _user = new()
    {
        LastName = "Test",
        FirstName = "Test",
        Username = "Username",
        Password = "Password",
        Salt1 = "Salt",
        Salt2 = "Salt",
        Salt3 = "Salt",
        Salt4 = "Salt",
        CompanyId = Guid.NewGuid(),
        OwnCompany = new OwnCompany { Name = "Test" },
        UserInGroups = new List<UserInGroup>(),
        UserInRoles = new List<UserInRole>()
    };

    [Fact]
    public void Should_contain_companyId()
    {
        _user.CompanyId.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_contain_ownCompany()
    {
        _user.OwnCompany.Should().NotBeNull();
    }

    [Fact]
    public void Should_contain_userInGroups()
    {
        _user.UserInGroups.Should().BeEmpty();
    }

    [Fact]
    public void Should_contain_userInRoles()
    {
        _user.UserInRoles.Should().BeEmpty();
    }
}
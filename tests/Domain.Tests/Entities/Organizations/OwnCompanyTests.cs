using Domain.Entities.Organizations;
using FluentAssertions;

namespace Domain.Tests.Entities.Organizations;

public class OwnCompanyTests
{
    private OwnCompany _ownCompany = new()
    {
        Name = "Test",
        Users = new List<User>()
    };

    [Fact]
    public void Should_contain_users()
    {
        _ownCompany.Users.Should().BeEmpty();
    }
}
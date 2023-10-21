using Application.Features.Organizations.OwnCompanies.GetAll;
using FluentAssertions;

namespace Application.Tests.Features.Organizations.OwnCompanies.GetAll;

public class GetAllOwnCompanyQueryTests
{
    [Fact]
    public void Should_contain_nullable_isDeleted()
    {
        // Act
        var query = new GetAllOwnCompanyQuery(true);
        
        // Assert
        query.IsDeleted.Should().BeTrue();
    }
}
using Application.Features.Organizations.OwnCompanies.Create;
using Contracts.Requests.Organizations.V1;
using FluentAssertions;

namespace Application.Tests.Features.Organizations.OwnCompanies.Create;

public class CreateOwnCompanyCommandTests
{
    [Fact]
    public void Should_hold_create_own_company_request()
    {
        // Arrange
        var command = new CreateOwnCompanyCommand(new CreateOwnCompanyRequest
        {
            CorporateId = "1234567890",
            Name = "Test", 
            UserId = Guid.NewGuid()
        });
        
        // Assert
        command.Request.Should().BeOfType<CreateOwnCompanyRequest>();
    }
}
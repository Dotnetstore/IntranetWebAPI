using Application.Common.Mappers.Organizations.V1;
using Application.Features.Organizations.OwnCompanies.Create;
using Contracts.Requests.Organizations.V1;
using FluentAssertions;
using FluentAssertions.Execution;
using TestHelper.FakeData;

namespace Application.Tests.Common.Mappers.Organizations.V1;

public class OwnCompanyMappersTests
{
    [Fact]
    public void Should_return_correct_dto_object()
    {
        // Arrange
        var ownCompany = OrganizationFakeData.GenerateOwnCompanyFakeData(1).Single();
        
        // Act
        var dto = ownCompany.ToDto();
        
        // Assert
        ownCompany.Should().BeEquivalentTo(dto);
    }

    [Fact]
    public void Should_convert_create_request_to_entity()
    {
        // Arrange
        var command = new CreateOwnCompanyCommand(new CreateOwnCompanyRequest
        {
            CorporateId = "1234567890",
            Name = "Test", 
            UserId = Guid.NewGuid()
        });
        
        // Act
        var entity = command.Request.ToEntity();

        // Assert
        using (new AssertionScope())
        {
            entity.CorporateId.Should().Be("1234567890");
            entity.Name.Should().Be("Test");
            entity.CreatedBy.Should().NotBeEmpty();
            entity.CreatedDate.Should().BeAfter(DateTimeOffset.Now.AddMinutes(-1));
        }
    }
}
using Application.Common.Mappers.Organizations.V1;
using Contracts.Responses.Organizations.V1;
using FluentAssertions;
using TestHelper.FakeData;

namespace Contract.Tests.Responses.Organizations.V1;

public class CreateOwnCompanyResponseTests
{
    [Fact]
    public void Should_hold_own_company_dto()
    {
        // Arrange
        var entity = OrganizationFakeData.GenerateOwnCompanyFakeData(1).Single();
        var dto = entity.ToDto();
        
        // Act
        var response = new CreateOwnCompanyResponse(dto);
        
        // Assert
        response.OwnCompany.Should().Be(dto);
    }
}
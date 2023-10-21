using Application.Common.Mappers.Organizations;
using FluentAssertions;
using TestHelper.FakeData;

namespace Application.Tests.Common.Mappers.Organizations;

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
}
using Application.Features.Organizations.OwnCompanies.Create;
using Application.Features.Organizations.OwnCompanies.GetAll;
using Contracts.Dtos.Organizations.V1;
using Contracts.Requests.Organizations.V1;
using Contracts.Responses.Organizations.V1;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Presentation.Controllers.Organizations.V1;

namespace Presentation.Tests.Controllers.Organizations.V1;

public class OwnCompanyControllerTests
{
    [Fact]
    public async Task Should_return_all_objects()
    {
        // Arrange
        var expectedResult = new List<OwnCompanyDto>
        {
            new() { Id = Guid.NewGuid(), Name = "Company1", IsDeleted = true},
            new() { Id = Guid.NewGuid(), Name = "Company2", IsDeleted = false}
        };

        var sender = Substitute.For<ISender>();
        sender.Send(Arg.Any<GetAllOwnCompanyQuery>(), Arg.Any<CancellationToken>())
            .Returns(expectedResult);

        var controller = new OwnCompanyController(sender);

        // Act
        var result = await controller.GetAsync(isDeleted: true, cancellationToken: CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var actualResult = Assert.IsAssignableFrom<IEnumerable<OwnCompanyDto>>(okResult.Value);

        actualResult.Count().Should().Be(2);
    }
    
    [Fact]
    public async Task CreateAsync_WithValidRequest_ReturnsCreatedResult()
    {
        // Arrange
        var request = new CreateOwnCompanyRequest
        {
            CorporateId = "SE7101263924",
            Name = "Test",
            UserId = null
        };

        var dto = new OwnCompanyDto
        {
            Id = Guid.NewGuid(),
            Name = "Test"
        };

        var response = new CreateOwnCompanyResponse(dto);

        var sender = Substitute.For<ISender>();
        sender.Send(Arg.Any<CreateOwnCompanyCommand>(), Arg.Any<CancellationToken>())
            .Returns(response);

        var controller = new OwnCompanyController(sender);

        // Act
        var result = await controller.CreateAsync(request, CancellationToken.None);

        // Assert
        var createdResult = Assert.IsType<OkObjectResult>(result);
        var actualResult = Assert.IsAssignableFrom<CreateOwnCompanyResponse>(createdResult.Value);

        dto.Id.Should().Be(actualResult.OwnCompany.Id);
    }
}
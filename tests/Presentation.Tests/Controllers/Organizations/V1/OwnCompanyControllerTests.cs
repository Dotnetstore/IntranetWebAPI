using Application.Features.Organizations.OwnCompanies.GetAll;
using Contracts.Dtos.Organizations.V1;
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
}
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Extensions;

namespace Presentation.Tests.Extensions;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddWebApi_ShouldAddMediator()
    {
        // Arrange
        IServiceCollection serviceCollection = new ServiceCollection();

        // Act
        serviceCollection.AddWebApi();

        // Assert
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var mediator = serviceProvider.GetService<IMediator>();

        mediator.Should().NotBeNull();
    }
}
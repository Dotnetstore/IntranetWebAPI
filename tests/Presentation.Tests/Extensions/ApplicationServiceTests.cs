using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Presentation.Extensions;

namespace Presentation.Tests.Extensions;

public class ApplicationServiceTests
{
    private WebApplicationBuilder _builder = WebApplication.CreateBuilder();
    private WebApplication _webApplication = null!;

    [Fact]
    public void AddServices_should_return_webApplicationBuilder()
    {
        var result = _builder.AddServices();

        result.Should().BeOfType<WebApplicationBuilder>();
    }

    [Fact]
    public void AddWebApiServices_should_return_webApplication()
    {
        var result = _builder.AddWebApiServices();

        result.Should().BeOfType<WebApplication>();
    }

    [Fact]
    public void AddSwagger_should_return_webApplication()
    {
        _webApplication = _builder.Build();
        
        var result = _webApplication.AddSwagger();

        result.Should().BeOfType<WebApplication>();
    }
}
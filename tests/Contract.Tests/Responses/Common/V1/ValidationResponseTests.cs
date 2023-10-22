using Contracts.Responses.Common.V1;
using FluentAssertions;

namespace Contract.Tests.Responses.Common.V1;

public class ValidationResponseTests
{
    [Fact]
    public void Should_contain_propertyName()
    {
        // Arrange
        var response = new ValidationResponse
        {
            Message = "Test1",
            PropertyName = "Test2"
        };

        // Assert
        response.PropertyName.Should().Be("Test2");
    }
    
    [Fact]
    public void Should_contain_message()
    {
        // Arrange
        var response = new ValidationResponse
        {
            Message = "Test1",
            PropertyName = "Test2"
        };

        // Assert
        response.Message.Should().Be("Test1");
    }
}
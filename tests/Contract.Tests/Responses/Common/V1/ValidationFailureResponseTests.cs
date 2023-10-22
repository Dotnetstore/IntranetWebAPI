using Contracts.Responses.Common.V1;
using FluentAssertions;

namespace Contract.Tests.Responses.Common.V1;

public class ValidationFailureResponseTests
{
    [Fact]
    public void Should_contain_error_list()
    {
        // Arrange
        var errors = new List<ValidationResponse>
        {
            new() { Message = "Message1", PropertyName = "Property1" },
            new() { Message = "Message2", PropertyName = "Property2" }
        };

        var response = new ValidationFailureResponse { Errors = errors };
        
        // Assert
        response.Errors.Count().Should().Be(2);
    }
}
using Domain.Exceptions;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Domain.Tests.Exceptions;

public class SwedishCorporateNumberExceptionTests
{
    [Fact]
    public void Should_have_parameterless_constructor()
    {
        var exception = new SwedishCorporateNumberException();

        exception.Should().BeOfType<SwedishCorporateNumberException>();
    }

    [Fact]
    public void Should_have_constructor_with_message_parameter()
    {
        var exception = new SwedishCorporateNumberException("Test");

        exception.Message.Should().Be("Test");
    }

    [Fact]
    public void Should_have_constructor_with_message_and_innerException_parameter()
    {
        var innerException = new Exception("Inner");
        var exception = new SwedishCorporateNumberException("Test", innerException);

        using (new AssertionScope())
        {
            exception.Message.Should().Be("Test");
            exception.InnerException?.Message.Should().Be("Inner");
        }
    }
}
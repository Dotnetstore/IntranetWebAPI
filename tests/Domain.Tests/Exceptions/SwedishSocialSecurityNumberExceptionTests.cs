﻿using Domain.Exceptions;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Domain.Tests.Exceptions;

public class SwedishSocialSecurityNumberExceptionTests
{
    [Fact]
    public void Should_have_parameterless_constructor()
    {
        var exception = new SwedishSocialSecurityNumberException();

        exception.Should().BeOfType<SwedishSocialSecurityNumberException>();
    }

    [Fact]
    public void Should_have_constructor_with_message_parameter()
    {
        var exception = new SwedishSocialSecurityNumberException("Test");

        exception.Message.Should().Be("Test");
    }

    [Fact]
    public void Should_have_constructor_with_message_and_innerException_parameter()
    {
        var innerException = new Exception("Inner");
        var exception = new SwedishSocialSecurityNumberException("Test", innerException);

        using (new AssertionScope())
        {
            exception.Message.Should().Be("Test");
            exception.InnerException?.Message.Should().Be("Inner");
        }
    }
}
using Domain.Errors.Organizations;
using Domain.Resources;
using ErrorOr;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Domain.Tests.Errors.Organizations;

public class OwnCompanyErrorsTests
{
    [Fact]
    public void Should_have_nameIsRequired()
    {
        var result = OwnCompanyErrors.NameIsRequired;

        using (new AssertionScope())
        {
            result.Type.Should().Be(ErrorType.Validation);
            result.Code.Should().Be("OwnCompany.NameIsRequired");
            result.Description.Should().Be(Validation.NameIsRequired);
        }
    }
}
using Domain.Common;
using FluentAssertions;

namespace Domain.Tests.Common;

public class CompanyTests
{
    private TestCompany _testCompany = null!;

    [Fact]
    public void Should_contain_name()
    {
        const string name = "Test";
        _testCompany = new TestCompany() { Name = name };

        _testCompany.Name.Should().Be(name);
    }

    [Fact]
    public void Should_contain_corporateId()
    {
        const string name = "Test";
        const string corporateId = "1234567890";
        _testCompany = new TestCompany() { Name = name, CorporateId = corporateId};

        _testCompany.CorporateId.Should().Be(corporateId);
    }
}

public class TestCompany : Company{}
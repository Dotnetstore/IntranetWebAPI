using Domain.Common;
using Domain.Entities.Organizations;
using FluentAssertions;
using TestHelper.FakeData;

namespace Domain.Tests.Common;

public sealed class BaseAuditableEntityTests
{
    private readonly OwnCompany _ownCompany = OrganizationFakeData.GenerateOwnCompanyFakeData(1).Single();

    [Fact]
    public void Should_contain_createdBy()
    {
        _ownCompany.CreatedBy.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_contain_createdDate()
    {
        _ownCompany.CreatedDate.Should().BeAfter(DateTimeOffset.MinValue);
    }

    [Fact]
    public void Should_contain_lastUpdatedBy()
    {
        _ownCompany.LastUpdatedBy.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_contain_lastUpdatedDate()
    {
        _ownCompany.LastUpdatedDate.Should().BeAfter(DateTimeOffset.MinValue);
    }

    [Fact]
    public void Should_contain_deletedBy()
    {
        _ownCompany.DeletedBy.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_contain_deletedDate()
    {
        _ownCompany.DeletedDate.Should().BeAfter(DateTimeOffset.MinValue);
    }

    [Fact]
    public void Should_contain_isDeleted()
    {
        if (_ownCompany.IsDeleted)
            _ownCompany.IsDeleted.Should().BeTrue();
        else
            _ownCompany.IsDeleted.Should().BeFalse();
    }

    [Fact]
    public void Should_contain_isSystem()
    {
        if (_ownCompany.IsSystem)
            _ownCompany.IsSystem.Should().BeTrue();
        else
            _ownCompany.IsSystem.Should().BeFalse();
    }

    [Fact]
    public void Should_contain_isGdpr()
    {
        if (_ownCompany.IsGdpr)
            _ownCompany.IsGdpr.Should().BeTrue();
        else
            _ownCompany.IsGdpr.Should().BeFalse();
    }
}
using Domain.Common;
using Domain.Entities.Organizations;
using FluentAssertions;
using TestHelper.FakeData;

namespace Domain.Tests.Common;

public class BaseEntityTests
{
    private readonly OwnCompany _ownCompany = OrganizationFakeData.GenerateOwnCompanyFakeData(1).Single();

    [Fact]
    public void Should_contain_Id()
    {
        _ownCompany.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_contain_domainEvents()
    {
        _ownCompany.DomainEvents.Should().BeEmpty();
    }

    [Fact]
    public void Should_be_able_to_add_domainEvent()
    {
        var testEvent = new TestBaseEntityEvent();
        
        _ownCompany.AddDomainEvent(testEvent);

        _ownCompany.DomainEvents.First().Should().Be(testEvent);
    }

    [Fact]
    public void Should_be_able_to_remove_domainEvent()
    {
        var testEvent = new TestBaseEntityEvent();
        
        _ownCompany.AddDomainEvent(testEvent);
        _ownCompany.RemoveDomainEvent(testEvent);

        _ownCompany.DomainEvents.Should().BeEmpty();
    }

    [Fact]
    public void Should_be_able_to_clear_domainEvent()
    {
        var testEvent = new TestBaseEntityEvent();
        
        _ownCompany.AddDomainEvent(testEvent);
        _ownCompany.ClearDomainEvents();

        _ownCompany.DomainEvents.Should().BeEmpty();
    }
}

public class TestBaseEntityEvent : BaseEvent{}
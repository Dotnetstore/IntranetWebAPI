using Domain.Common;
using FluentAssertions;

namespace Domain.Tests.Common;

public class BaseEventTests
{
    private TestBaseEvent _testObject = null!;

    [Fact]
    public void Should_contain_dateOccurred()
    {
        _testObject = new TestBaseEvent();

        _testObject.DateOccurred.Should().BeAfter(DateTimeOffset.MinValue);
    }
}

public class TestBaseEvent : BaseEvent{}
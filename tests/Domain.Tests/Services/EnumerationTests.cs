using Domain.Services;
using FluentAssertions;

namespace Domain.Tests.Services;

public class EnumerationTests
{
    public class TestEnumeration : Enumeration<TestEnumeration>
    {
        public static readonly TestEnumeration First = new TestEnumeration(Guid.NewGuid(), "First");
        public static readonly TestEnumeration Second = new TestEnumeration(Guid.NewGuid(), "Second");

        private TestEnumeration(Guid value, string name) : base(value, name) { }
    }
    
    [Fact]
    public void FromValue_ReturnsCorrectEnumeration()
    {
        // Arrange
        var value = TestEnumeration.First.Value;

        // Act
        var result = TestEnumeration.FromValue(value)!;

        // Assert
        TestEnumeration.First.Should().Be(result);
    }

    [Fact]
    public void FromValue_ReturnsNullForInvalidValue()
    {
        // Arrange
        var invalidValue = Guid.NewGuid();

        // Act
        var result = TestEnumeration.FromValue(invalidValue)!;

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void FromName_ReturnsCorrectEnumeration()
    {
        // Arrange
        var name = TestEnumeration.Second.Name;

        // Act
        var result = TestEnumeration.FromName(name)!;

        // Assert
        TestEnumeration.Second.Should().Be(result);
    }

    [Fact]
    public void FromName_ReturnsNullForInvalidName()
    {
        // Arrange
        var invalidName = "InvalidName";

        // Act
        var result = TestEnumeration.FromName(invalidName)!;

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void Equals_ReturnsTrueForEqualEnumerations()
    {
        // Arrange
        var first = TestEnumeration.First;
        var second = TestEnumeration.FromValue(first.Value)!;

        // Act
        var result = first.Equals(second);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_ReturnsFalseForDifferentEnumerations()
    {
        // Arrange
        var first = TestEnumeration.First;
        var second = TestEnumeration.Second;

        // Act
        var result = first.Equals(second);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_should_be_calculated()
    {
        // Arrange
        var first = TestEnumeration.First;

        // Act
        var result = first.GetHashCode();

        // Assert
        result.Should().BeGreaterThan(int.MinValue);
    }
}
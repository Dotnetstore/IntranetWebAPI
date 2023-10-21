using Application.Extensions;
using FluentAssertions;

namespace Application.Tests.Extensions;

public class QueryableExtensionsTests
{
    [Fact]
    public void WhereNullable_WithNonNullParameter_ShouldFilterSource()
    {
        // Arrange
        var source = new List<int> { 1, 2, 3, 4 }.AsQueryable();
        int? parameter = 2;

        // Act
        var result = source.WhereNullable(parameter, x => x % 2 == 0);

        // Assert
        result.Should().BeEquivalentTo(new[] { 2, 4 });
    }
    
    [Fact]
    public void WhereNullable_WithNullParameter_ShouldReturnOriginalSource()
    {
        // Arrange
        var source = new List<int> { 1, 2, 3, 4 }.AsQueryable();
        int? parameter = null;

        // Act
        var result = source.WhereNullable(parameter, x => x % 2 == 0);

        // Assert
        result.Should().BeEquivalentTo(new[] { 1, 2, 3, 4 });
    }
    
    [Fact]
    public void WhereNullable_WithNullPredicate_ShouldThrowArgumentNullException()
    {
        // Arrange
        var source = new List<int> { 1, 2, 3, 4 }.AsQueryable();
        int? parameter = 2;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            source.WhereNullable(parameter, null);
        });
    }
}
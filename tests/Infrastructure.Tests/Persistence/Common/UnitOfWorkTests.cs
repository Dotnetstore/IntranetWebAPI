using Application.Common.Interfaces.Common;
using Domain.Entities.Organizations;
using FluentAssertions;
using Infrastructure.Contexts;
using Infrastructure.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using TestHelper.FakeData;

namespace Infrastructure.Tests.Persistence.Common;

public class UnitOfWorkTests : IDisposable
{
    private readonly DotnetstoreIntranetContext _context;
    private IUnitOfWork _unitOfWork;

    public UnitOfWorkTests()
    {
        var options = new DbContextOptionsBuilder<DotnetstoreIntranetContext>()
            .UseInMemoryDatabase(databaseName: "test_database")
            .Options;

        _context = new DotnetstoreIntranetContext(options);
        _unitOfWork = new UnitOfWork(_context);
    }
    
    [Fact]
    public void Should_return_correct_repository_instance()
    {
        // Act
        var repository = _unitOfWork.Repository<OwnCompany>();

        // Assert
        repository.Should().BeOfType<GenericRepository<OwnCompany>>();
    }

    [Fact]
    public async Task Should_return_saved_changes()
    {
        // Arrange
        var entity = OrganizationFakeData.GenerateOwnCompanyFakeData(1).Single();
        _unitOfWork.Repository<OwnCompany>().Create(entity);

        // Act
        var result = await _unitOfWork.SaveAsync(CancellationToken.None);

        // Assert
        result.Should().Be(1);
    }
    
    [Fact]
    public void Should_reload_all_entities()
    {
        // Arrange
        var entity = OrganizationFakeData.GenerateOwnCompanyFakeData(1).Single();
        _unitOfWork.Repository<OwnCompany>().Create(entity);

        // Act
        _unitOfWork.Rollback();

        // Assert
        var entry = _context.Entry(entity);
        entry.State.Should().Be(EntityState.Unchanged);
    }

    public void Dispose()
    {
        _context.Dispose();
        _unitOfWork.Dispose();
    }
}
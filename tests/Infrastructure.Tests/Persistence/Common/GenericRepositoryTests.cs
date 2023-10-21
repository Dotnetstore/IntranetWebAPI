using Application.Common.Interfaces.Common;
using Domain.Entities.Organizations;
using FluentAssertions;
using Infrastructure.Contexts;
using Infrastructure.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using TestHelper.FakeData;

namespace Infrastructure.Tests.Persistence.Common;

public class GenericRepositoryTests : IDisposable
{
    private readonly DotnetstoreIntranetContext _context;
    private readonly IGenericRepository<OwnCompany> _repository;

    public GenericRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<DotnetstoreIntranetContext>()
            .UseInMemoryDatabase(databaseName: "test_database")
            .Options;

        _context = new DotnetstoreIntranetContext(options);
        _repository = new GenericRepository<OwnCompany>(_context);

        var entities = OrganizationFakeData.GenerateOwnCompanyFakeData(10).ToList();

        foreach (var entity in entities)
        {
            entity.Id = Guid.NewGuid();
        }
        
        _context.AddRange(entities);
        _context.SaveChanges();
    }
    
    [Fact]
    public async Task Should_return_correct_entity_by_id()
    {
        // Arrange
        var entity = _context.OwnCompanies.First();

        // Act
        var result = await _repository.GetByIdAsync(entity.Id);

        // Assert
        result.Should().Be(entity);
    }
    
    [Fact]
    public async Task _Should_return_all_entities()
    {
        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        result.Should().NotBeEmpty();
    }
    
    [Fact]
    public void Should_set_entityState_to_created()
    {
        // Arrange
        var entity = OrganizationFakeData.GenerateOwnCompanyFakeData(1).Single();

        // Act
        _repository.Create(entity);

        // Assert
        // var result = _context.Set<OwnCompany>().Find(entity.Id);
        _context.Entry(entity).State.Should().Be(EntityState.Added);
    }
    
    [Fact]
    public void Should_set_entityState_to_modified()
    {
        // Arrange
        var entity = _context.OwnCompanies.First();

        // Act
        _repository.Update(entity);

        // Assert
        _context.Entry(entity).State.Should().Be(EntityState.Modified);
    }
    
    [Fact]
    public void Should_set_entityState_to_deleted()
    {
        // Arrange
        var entity = _context.OwnCompanies.First();

        // Act
        _repository.Delete(entity);

        // Assert
        _context.Entry(entity).State.Should().Be(EntityState.Deleted);
    }

    [Fact]
    public void Should_have_correct_entities()
    {
        // Act
        var result = _repository.Entities.ToList();

        // Assert
        result.Should().BeOfType<List<OwnCompany>>();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
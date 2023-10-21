using Application.Common.Interfaces.Common;
using Application.Features.Organizations.OwnCompanies.GetAll;
using Contracts.Dtos.Organizations;
using Domain.Entities.Organizations;
using FluentAssertions;
using Infrastructure.Contexts;
using Infrastructure.Persistence.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests.Features.Organizations.OwnCompanies.GetAll;

public class GetAllOwnCompanyQueryHandlerTests : IDisposable
{
    private readonly DotnetstoreIntranetContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private IRequestHandler<GetAllOwnCompanyQuery, IEnumerable<OwnCompanyDto>> _handler;
    
    public GetAllOwnCompanyQueryHandlerTests()
    {
        var options = new DbContextOptionsBuilder<DotnetstoreIntranetContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new DotnetstoreIntranetContext(options);
        _unitOfWork = new UnitOfWork(_context);
        _handler = new GetAllOwnCompanyQueryHandler(_unitOfWork);
        
        _context.OwnCompanies.AddRange(new List<OwnCompany>
        {
            new() { Name = "Company1", IsDeleted = true },
            new() { Name = "Company2", IsDeleted = false },
            new() { Name = "Company3", IsDeleted = true }
        });

        _context.SaveChanges();
    }
    
    [Fact]
    public async Task Should_return_deleted_objects()
    {
        // Arrange
        var request = new GetAllOwnCompanyQuery { IsDeleted = true };
        
        // Act
        var result = await _handler.Handle(request, CancellationToken.None);
        
        // Assert
        result.Count().Should().Be(2);
    }
    
    [Fact]
    public async Task Should_return_not_deleted_objects()
    {
        // Arrange
        var request = new GetAllOwnCompanyQuery { IsDeleted = false };
        
        // Act
        var result = await _handler.Handle(request, CancellationToken.None);
        
        // Assert
        result.Count().Should().Be(1);
    }

    public void Dispose()
    {
        _context.Dispose();
        _unitOfWork.Dispose();
    }
}
using Application.Common.Interfaces.Common;
using Application.Features.Organizations.OwnCompanies.Create;
using Contracts.Requests.Organizations.V1;
using Contracts.Responses.Organizations.V1;
using FluentAssertions;
using FluentValidation;
using Infrastructure.Contexts;
using Infrastructure.Persistence.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests.Features.Organizations.OwnCompanies.Create;

public class CreateOwnCompanyCommandHandlerTests
{
    private CancellationToken _token;
    private readonly DotnetstoreIntranetContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private IRequestHandler<CreateOwnCompanyCommand, CreateOwnCompanyResponse> _handler;
    private IValidator<CreateOwnCompanyRequest> _validator;
    
    public CreateOwnCompanyCommandHandlerTests()
    {
        _validator = new CreateOwnCompanyCommandValidator();

        _token = new CancellationTokenSource().Token;
        
        var options = new DbContextOptionsBuilder<DotnetstoreIntranetContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new DotnetstoreIntranetContext(options);
        _unitOfWork = new UnitOfWork(_context);
        _handler = new CreateOwnCompanyCommandHandler(_unitOfWork, _validator);
    }

    [Fact]
    public async Task Should_be_able_to_create_own_company()
    {
        // Arrange
        var command = new CreateOwnCompanyCommand(new CreateOwnCompanyRequest
        {
            CorporateId = "SE7101263924",
            Name = "Test", 
            UserId = Guid.NewGuid()
        });

        // Act
        var result = await _handler.Handle(command, _token);
        
        // Assert
        result.Should().BeOfType<CreateOwnCompanyResponse>();
    }

    [Fact]
    public async Task Should_throw_exception_due_to_bad_corporateid()
    {
        // Arrange
        var command = new CreateOwnCompanyCommand(new CreateOwnCompanyRequest
        {
            CorporateId = "SE7101263925",
            Name = "Test", 
            UserId = Guid.NewGuid()
        });

        // Act
        var result = async () => await _handler.Handle(command, _token);
        
        // Assert
        await result.Should().ThrowAsync<Exception>();
    }
    
    [Fact]
    public async Task Should_throw_exception_due_to_bad_name()
    {
        // Arrange
        var command = new CreateOwnCompanyCommand(new CreateOwnCompanyRequest
        {
            CorporateId = "SE7101263924",
            Name = "", 
            UserId = Guid.NewGuid()
        });

        // Act
        var result = async () => await _handler.Handle(command, _token);
        
        // Assert
        await result.Should().ThrowAsync<Exception>();
    }
    
    [Fact]
    public async Task Should_throw_exception_due_to_bad_userId()
    {
        // Arrange
        var command = new CreateOwnCompanyCommand(new CreateOwnCompanyRequest
        {
            CorporateId = "SE7101263924",
            Name = "Test", 
            UserId = Guid.Empty
        });

        // Act
        var result = async () => await _handler.Handle(command, _token);
        
        // Assert
        await result.Should().ThrowAsync<Exception>();
    }
}
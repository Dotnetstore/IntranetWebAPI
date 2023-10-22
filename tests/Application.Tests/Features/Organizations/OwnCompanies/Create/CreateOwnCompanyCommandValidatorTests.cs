using Application.Features.Organizations.OwnCompanies.Create;
using Contracts.Requests.Organizations.V1;
using FluentAssertions;
using FluentValidation;

namespace Application.Tests.Features.Organizations.OwnCompanies.Create;

public class CreateOwnCompanyCommandValidatorTests
{
    private readonly IValidator<CreateOwnCompanyRequest> _validator = new CreateOwnCompanyCommandValidator();

    [Fact]
    public async Task Should_fail_validation_due_to_too_short_name()
    {
        // Arrange
        var command = new CreateOwnCompanyCommand(new CreateOwnCompanyRequest
        {
            CorporateId = "SE7101263924",
            Name = "", 
            UserId = Guid.NewGuid()
        });

        var valitation = await _validator.ValidateAsync(command.Request);

        valitation.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public async Task Should_fail_validation_due_to_too_long_name()
    {
        // Arrange
        var command = new CreateOwnCompanyCommand(new CreateOwnCompanyRequest
        {
            CorporateId = "SE7101263924",
            Name = "a".PadRight(101, 'a'), 
            UserId = Guid.NewGuid()
        });

        var valitation = await _validator.ValidateAsync(command.Request);

        valitation.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public async Task Should_fail_validation_due_to_too_null_name()
    {
        // Arrange
        var command = new CreateOwnCompanyCommand(new CreateOwnCompanyRequest
        {
            CorporateId = "SE7101263924",
            Name = null, 
            UserId = Guid.NewGuid()
        });

        var valitation = await _validator.ValidateAsync(command.Request);

        valitation.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public async Task Should_fail_validation_due_to_too_invalid_corporateId()
    {
        // Arrange
        var command = new CreateOwnCompanyCommand(new CreateOwnCompanyRequest
        {
            CorporateId = "SE7101263925",
            Name = "Test", 
            UserId = Guid.NewGuid()
        });

        var valitation = await _validator.ValidateAsync(command.Request);

        valitation.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public async Task Should_fail_validation_due_to_too_invalid_userId()
    {
        // Arrange
        var command = new CreateOwnCompanyCommand(new CreateOwnCompanyRequest
        {
            CorporateId = "SE7101263924",
            Name = "Test", 
            UserId = Guid.Empty
        });

        var valitation = await _validator.ValidateAsync(command.Request);

        valitation.IsValid.Should().BeFalse();
    }
}
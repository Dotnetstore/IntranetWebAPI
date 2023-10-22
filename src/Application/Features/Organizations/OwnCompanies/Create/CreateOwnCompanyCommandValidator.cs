using Contracts.Requests.Organizations.V1;
using Domain.Validations;
using FluentValidation;

namespace Application.Features.Organizations.OwnCompanies.Create;

public class CreateOwnCompanyCommandValidator : AbstractValidator<CreateOwnCompanyRequest>
{
    public CreateOwnCompanyCommandValidator()
    {
        RuleFor(q => q.Name)
            .NotNull()
            .MinimumLength(1)
            .MaximumLength(100)
            .WithMessage("Name is required and must have 1-100 characters.");

        RuleFor(q => q.CorporateId)
            .Must(ValidateCorporateId)
            .WithMessage("CorporateId is not valid. Must start with country code (i.e. SE, DE, CN) followed by the id.");

        RuleFor(q => q.UserId)
            .Must(ValidateUserId)
            .WithMessage("Empty user id is not allowed.");
    }

    private static bool ValidateUserId(Guid? arg)
    {
        return new OptionalGuidAttribute().IsValid(arg);
    }

    private static bool ValidateCorporateId(string? arg)
    {
        return new CorporateIdAttribute().IsValid(arg);
    }
}
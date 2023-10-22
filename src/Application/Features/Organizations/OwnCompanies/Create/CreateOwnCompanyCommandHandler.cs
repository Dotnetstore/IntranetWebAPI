using Application.Common.Interfaces.Common;
using Application.Common.Mappers.Organizations.V1;
using Contracts.Requests.Organizations.V1;
using Contracts.Responses.Organizations.V1;
using Domain.Entities.Organizations;
using FluentValidation;
using MediatR;

namespace Application.Features.Organizations.OwnCompanies.Create;

internal sealed class CreateOwnCompanyCommandHandler : IRequestHandler<CreateOwnCompanyCommand, CreateOwnCompanyResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateOwnCompanyRequest> _validator;

    public CreateOwnCompanyCommandHandler(
        IUnitOfWork unitOfWork,
        IValidator<CreateOwnCompanyRequest> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    
    async Task<CreateOwnCompanyResponse> IRequestHandler<CreateOwnCompanyCommand, CreateOwnCompanyResponse>
        .Handle(CreateOwnCompanyCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Request, cancellationToken);

        var entity = request.Request.ToEntity();
        
        _unitOfWork.Repository<OwnCompany>().Create(entity);
        await _unitOfWork.SaveAsync(cancellationToken);

        return new CreateOwnCompanyResponse(entity.ToDto());
    }
}
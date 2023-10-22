using Application.Common.Interfaces.Common;
using Application.Common.Mappers.Organizations.V1;
using Application.Extensions;
using Contracts.Dtos.Organizations.V1;
using Domain.Entities.Organizations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Organizations.OwnCompanies.GetAll;

internal sealed class GetAllOwnCompanyQueryHandler : IRequestHandler<GetAllOwnCompanyQuery, IEnumerable<OwnCompanyDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOwnCompanyQueryHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    async Task<IEnumerable<OwnCompanyDto>> IRequestHandler<GetAllOwnCompanyQuery, IEnumerable<OwnCompanyDto>>
        .Handle(GetAllOwnCompanyQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork
            .Repository<OwnCompany>()
            .Entities
            .WhereNullable(request.IsDeleted, q => q.IsDeleted == request.IsDeleted)
            .OrderBy(q => q.Name)
            .ThenBy(q => q.CorporateId)
            .Select(q => q.ToDto())
            .ToListAsync(cancellationToken);
    }
}
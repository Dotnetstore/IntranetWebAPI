using Contracts.Dtos.Organizations;
using Contracts.Dtos.Organizations.V1;
using MediatR;

namespace Application.Features.Organizations.OwnCompanies.GetAll;

public record struct GetAllOwnCompanyQuery(bool? IsDeleted) : IRequest<IEnumerable<OwnCompanyDto>>;
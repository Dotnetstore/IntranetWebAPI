using Contracts.Dtos.Organizations;
using MediatR;

namespace Application.Features.Organizations.OwnCompanies.GetAll;

public record struct GetAllOwnCompanyQuery(bool? IsDeleted) : IRequest<IEnumerable<OwnCompanyDto>>;
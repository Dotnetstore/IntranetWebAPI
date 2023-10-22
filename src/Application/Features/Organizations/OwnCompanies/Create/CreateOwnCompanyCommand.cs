using Contracts.Requests.Organizations.V1;
using Contracts.Responses.Organizations.V1;
using MediatR;

namespace Application.Features.Organizations.OwnCompanies.Create;

public record struct CreateOwnCompanyCommand(CreateOwnCompanyRequest Request) : IRequest<CreateOwnCompanyResponse>;
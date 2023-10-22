using Application.Features.Organizations.OwnCompanies.Create;
using Application.Features.Organizations.OwnCompanies.GetAll;
using Asp.Versioning;
using Contracts.Dtos.Organizations.V1;
using Contracts.Requests.Organizations.V1;
using Contracts.Responses.Common.V1;
using Contracts.Responses.Organizations.V1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Swagger;

namespace Presentation.Controllers.Organizations.V1;

[ApiController]
[ApiVersion(1.0)]
public sealed class OwnCompanyController : ControllerBase
{
    private readonly ISender _sender;

    public OwnCompanyController(
        ISender sender)
    {
        _sender = sender;
    }

    [HttpGet(ApiEndPoints.OwnCompanyV1.GetAll)]
    [ProducesResponseType(typeof(IEnumerable<OwnCompanyDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromQuery] bool? isDeleted, CancellationToken cancellationToken)
    {
        var query = new GetAllOwnCompanyQuery(isDeleted);

        var result = await _sender.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpPost(ApiEndPoints.OwnCompanyV1.Create)]
    [ProducesResponseType(typeof(CreateOwnCompanyResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateOwnCompanyRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateOwnCompanyCommand(request);

        var result = await _sender.Send(command, cancellationToken);

        return Ok(result);
    }
}
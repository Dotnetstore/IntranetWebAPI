using Contracts.Dtos.Organizations;
using Domain.Entities.Organizations;

namespace Application.Common.Mappers.Organizations;

internal static class OwnCompanyMappers
{
    internal static OwnCompanyDto ToDto(this OwnCompany q)
    {
        return new OwnCompanyDto
        {
            Id = q.Id,
            CreatedBy = q.CreatedBy,
            CreatedDate = q.CreatedDate,
            LastUpdatedBy = q.LastUpdatedBy,
            LastUpdatedDate = q.LastUpdatedDate,
            DeletedBy = q.DeletedBy,
            DeletedDate = q.DeletedDate,
            IsDeleted = q.IsDeleted,
            IsSystem = q.IsSystem,
            IsGdpr = q.IsGdpr,
            Name = q.Name,
            CorporateId = q.CorporateId
        };
    }
}
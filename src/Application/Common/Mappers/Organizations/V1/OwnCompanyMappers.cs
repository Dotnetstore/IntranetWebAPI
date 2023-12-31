﻿using Contracts.Dtos.Organizations.V1;
using Contracts.Requests.Organizations.V1;
using Domain.Entities.Organizations;

namespace Application.Common.Mappers.Organizations.V1;

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

    internal static OwnCompany ToEntity(this CreateOwnCompanyRequest q)
    {
        return new OwnCompany
        {
            CorporateId = q.CorporateId,
            CreatedBy = q.UserId,
            CreatedDate = DateTimeOffset.Now,
            DeletedBy = null,
            DeletedDate = null,
            Id = Guid.NewGuid(),
            IsDeleted = false,
            IsGdpr = false,
            IsSystem = false,
            LastUpdatedDate = null,
            LastUpdatedBy = null,
            Name = q.Name
        };
    }
}
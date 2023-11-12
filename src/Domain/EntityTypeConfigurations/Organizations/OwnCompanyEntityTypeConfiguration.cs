using Domain.Entities.Organizations;
using Domain.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations.Organizations;

public class OwnCompanyEntityTypeConfiguration : CompanyEntityTypeConfiguration<OwnCompany>
{
    public override void Configure(EntityTypeBuilder<OwnCompany> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("OwnCompany", schema: "Organization");
    }
}
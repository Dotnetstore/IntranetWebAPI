using Domain.Entities.Organizations;
using Domain.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations.Organizations;

public class RoleEntityTypeConfiguration : BaseAuditableEntityEntityTypeConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("Role", schema: "Organization");

        builder
            .HasIndex(q => q.Name)
            .IsUnique();

        builder
            .Property(q => q.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(30)
            .HasColumnType("varchar(30)");
    }
}
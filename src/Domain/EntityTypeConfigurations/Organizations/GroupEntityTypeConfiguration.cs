using Domain.Entities.Organizations;
using Domain.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations.Organizations;

public class GroupEntityTypeConfiguration : BaseAuditableEntityEntityTypeConfiguration<Group>
{
    public override void Configure(EntityTypeBuilder<Group> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("Group", schema: "Organization");

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
using Domain.Entities.Organizations;
using Domain.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations.Organizations;

public class RoleInGroupEntityTypeConfiguration : BaseAuditableEntityEntityTypeConfiguration<RoleInGroup>
{
    public override void Configure(EntityTypeBuilder<RoleInGroup> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("RoleInGroup", schema: "Organization");

        builder
            .HasIndex(q => new { q.GroupId, q.RoleId })
            .IsUnique();

        builder
            .Property(q => q.GroupId)
            .IsRequired();

        builder
            .Property(q => q.RoleId)
            .IsRequired();

        builder
            .HasOne(q => q.Group)
            .WithMany(q => q.RoleInGroups)
            .HasForeignKey(q => q.GroupId)
            .IsRequired()
            .HasConstraintName("FK_Group_RoleInGroup");

        builder
            .HasOne(q => q.Role)
            .WithMany(q => q.RoleInGroups)
            .HasForeignKey(q => q.RoleId)
            .IsRequired()
            .HasConstraintName("FK_Role_RoleInGroup");
    }
}
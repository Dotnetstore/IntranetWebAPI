using Domain.Entities.Organizations;
using Domain.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations.Organizations;

public class UserInGroupEntityTypeConfiguration : BaseAuditableEntityEntityTypeConfiguration<UserInGroup>
{
    public override void Configure(EntityTypeBuilder<UserInGroup> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("UserInGroup", schema: "Organization");

        builder
            .HasIndex(q => new { q.GroupId, q.UserId })
            .IsUnique();

        builder
            .Property(q => q.GroupId)
            .IsRequired();

        builder
            .Property(q => q.UserId)
            .IsRequired();

        builder
            .HasOne(q => q.Group)
            .WithMany(q => q.UserInGroups)
            .HasForeignKey(q => q.GroupId)
            .IsRequired()
            .HasConstraintName("FK_Group_UserInGroup");

        builder
            .HasOne(q => q.User)
            .WithMany(q => q.UserInGroups)
            .HasForeignKey(q => q.UserId)
            .IsRequired()
            .HasConstraintName("FK_User_UserInGroup");
    }
}
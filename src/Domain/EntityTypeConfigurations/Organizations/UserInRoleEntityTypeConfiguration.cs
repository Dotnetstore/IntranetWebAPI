using Domain.Entities.Organizations;
using Domain.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations.Organizations;

public class UserInRoleEntityTypeConfiguration : BaseAuditableEntityEntityTypeConfiguration<UserInRole>
{
    public override void Configure(EntityTypeBuilder<UserInRole> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("UserInRole", schema: "Organization");

        builder
            .HasIndex(q => new { q.RoleId, q.UserId })
            .IsUnique();

        builder
            .Property(q => q.RoleId)
            .IsRequired();

        builder
            .Property(q => q.UserId)
            .IsRequired();

        builder
            .HasOne(q => q.Role)
            .WithMany(q => q.UserInRoles)
            .HasForeignKey(q => q.RoleId)
            .IsRequired()
            .HasConstraintName("FK_Role_UserInRole");

        builder
            .HasOne(q => q.User)
            .WithMany(q => q.UserInRoles)
            .HasForeignKey(q => q.UserId)
            .IsRequired()
            .HasConstraintName("FK_User_UserInRole");
    }
}
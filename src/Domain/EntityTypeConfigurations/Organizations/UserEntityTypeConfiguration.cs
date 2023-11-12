using Domain.Entities.Organizations;
using Domain.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations.Organizations;

public class UserEntityTypeConfiguration : UserIdentityEntityTypeConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("User", schema: "Organization");

        builder
            .Property(q => q.CompanyId)
            .IsRequired();

        builder
            .HasOne(q => q.OwnCompany)
            .WithMany(q => q.Users)
            .HasForeignKey(q => q.CompanyId)
            .IsRequired()
            .HasConstraintName("FK_OwnCompany_User");
    }
}
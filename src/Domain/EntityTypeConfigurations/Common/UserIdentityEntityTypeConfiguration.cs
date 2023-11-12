using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations.Common;

public class UserIdentityEntityTypeConfiguration<T> : PersonEntityTypeConfiguration<T> where T : UserIdentity
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder
            .HasIndex(q => q.Username)
            .IsUnique();

        builder
            .Property(q => q.Username)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(255)
            .HasColumnType("varchar(255)");

        builder
            .Property(q => q.Password)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(2000)
            .HasColumnType("varchar(2000)");

        builder
            .Property(q => q.Salt1)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");

        builder
            .Property(q => q.Salt2)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");

        builder
            .Property(q => q.Salt3)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");

        builder
            .Property(q => q.Salt4)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");

        builder
            .Property(q => q.IsBlocked)
            .IsRequired();
    }
}
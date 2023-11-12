using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations.Common;

public class PersonEntityTypeConfiguration<T> : BaseEntityEntityTypeConfiguration<T> where T : Person
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder
            .Property(q => q.LastName)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(25)
            .HasColumnType("nvarchar(25)");

        builder
            .Property(q => q.FirstName)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(25)
            .HasColumnType("nvarchar(25)");

        builder
            .Property(q => q.MiddleName)
            .IsRequired(false)
            .IsUnicode()
            .HasMaxLength(25)
            .HasColumnType("nvarchar(25)");

        builder
            .Property(q => q.EnglishName)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(25)
            .HasColumnType("nvarchar(25)");

        builder
            .Property(q => q.SocialSecurityNumber)
            .IsRequired(false)
            .IsUnicode(false)
            .HasMaxLength(30)
            .HasColumnType("varchar(30)");

        builder
            .Property(q => q.IsMale)
            .IsRequired();

        builder
            .Property(q => q.LastNameFirst)
            .IsRequired();
    }
}
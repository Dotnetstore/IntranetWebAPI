using Domain.Entities.Contacts;
using Domain.EntityTypeConfigurations.Common;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations.Contacts;

public class EmailInformationEntityTypeConfiguration : BaseAuditableEntityEntityTypeConfiguration<EmailInformation>
{
    public override void Configure(EntityTypeBuilder<EmailInformation> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("EmailInformation", schema: "Contact");

        builder
            .Property(q => q.EmailType)
            .HasConversion(q => q.Value,
                q => EmailType.FromValue(q)!);

        builder
            .Property(q => q.Text)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(255)
            .HasColumnType("varchar(255)");
    }
}
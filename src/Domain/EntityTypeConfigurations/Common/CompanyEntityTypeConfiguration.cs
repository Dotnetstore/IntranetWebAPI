using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations.Common;

public class CompanyEntityTypeConfiguration<T> : BaseAuditableEntityEntityTypeConfiguration<T> where T : Company
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder
            .Property(q => q.Name)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)");

        builder
            .Property(q => q.CorporateId)
            .IsRequired(false)
            .IsUnicode(false)
            .HasMaxLength(30)
            .HasColumnType("varchar(30)");
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 1 (Organisation & Lookups)
public class GradeScaleConfiguration : IEntityTypeConfiguration<GradeScale>
{
    public void Configure(EntityTypeBuilder<GradeScale> builder)
    {
        builder.ToTable("GradeScale");
        builder.HasKey(e => e.Letter);
        builder.Property(e => e.Letter).HasMaxLength(2);

        // TODO Group 1 (Organisation & Lookups): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

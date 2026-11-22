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

        // Columns
        builder.Property(e => e.GradePoints).HasPrecision(3, 2);
    }
}

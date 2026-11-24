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

        // Seed data (fixed lookup values, agreed by the team)
        // Grading scale from the UI-UX prototype. "A−" uses the minus sign (U+2212), as in the ERD.
        builder.HasData(
            new GradeScale { Letter = "A", MinTotal = 90, GradePoints = 4.00m },
            new GradeScale { Letter = "A−", MinTotal = 85, GradePoints = 3.70m },
            new GradeScale { Letter = "B+", MinTotal = 80, GradePoints = 3.30m },
            new GradeScale { Letter = "B", MinTotal = 75, GradePoints = 3.00m },
            new GradeScale { Letter = "C+", MinTotal = 70, GradePoints = 2.30m },
            new GradeScale { Letter = "C", MinTotal = 60, GradePoints = 2.00m },
            new GradeScale { Letter = "F", MinTotal = 0, GradePoints = 0.00m });
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 3 (Catalogue & Schedule)
public class AcademicTermConfiguration : IEntityTypeConfiguration<AcademicTerm>
{
    public void Configure(EntityTypeBuilder<AcademicTerm> builder)
    {
        builder.ToTable("AcademicTerm");
        builder.HasKey(e => e.TermID);

        // Columns
        builder.Property(e => e.AcademicYear).HasMaxLength(9);                      // e.g. 2026/2027
        builder.Property(e => e.TermName).HasConversion<string>().HasMaxLength(10); // TermName

        // Unique indexes: only one current term.
        // Other terms (IsCurrent = 0) are allowed (the filter skips them).
        builder.HasIndex(e => e.IsCurrent)
               .IsUnique()
               .HasFilter("[IsCurrent] = 1");
    }
}

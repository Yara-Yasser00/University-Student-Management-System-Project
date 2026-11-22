using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 3 (Catalogue & Schedule)
public class SchedulePublicationConfiguration : IEntityTypeConfiguration<SchedulePublication>
{
    public void Configure(EntityTypeBuilder<SchedulePublication> builder)
    {
        builder.ToTable("SchedulePublication");
        builder.HasKey(e => new { e.CollegeCode, e.TermID, e.Level });
        builder.Property(e => e.CollegeCode).HasMaxLength(10);
        builder.Property(e => e.Level).HasConversion<string>().HasMaxLength(10);

        // Columns
        builder.Property(e => e.Status).HasConversion<string>().HasMaxLength(20);       // PublicationStatus

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R22: SchedulePublication.CollegeCode → College
        builder.HasOne(e => e.College)
               .WithMany(p => p.SchedulePublications)
               .HasForeignKey(e => e.CollegeCode)
               .OnDelete(DeleteBehavior.Restrict);

        // R22: SchedulePublication.TermID → AcademicTerm
        builder.HasOne(e => e.Term)
               .WithMany(p => p.SchedulePublications)
               .HasForeignKey(e => e.TermID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

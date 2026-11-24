using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 4 (Registration)
public class GradeCorrectionConfiguration : IEntityTypeConfiguration<GradeCorrection>
{
    public void Configure(EntityTypeBuilder<GradeCorrection> builder)
    {
        builder.ToTable("GradeCorrection");
        builder.HasKey(e => e.CorrectionID);

        // Columns
        builder.Property(e => e.Component).HasConversion<string>().HasMaxLength(10);   // GradeComponent
        builder.Property(e => e.OldMark).HasPrecision(4, 1);
        builder.Property(e => e.NewMark).HasPrecision(4, 1);
        builder.Property(e => e.Reason).HasMaxLength(300);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R41: GradeCorrection.EnrollmentID → Enrollment
        builder.HasOne(e => e.Enrollment)
               .WithMany(p => p.GradeCorrections)
               .HasForeignKey(e => e.EnrollmentID)
               .OnDelete(DeleteBehavior.Restrict);

        // R42: GradeCorrection.CorrectedByAdminID → CollegeAdmin
        builder.HasOne(e => e.CorrectedByAdmin)
               .WithMany(p => p.GradeCorrections)
               .HasForeignKey(e => e.CorrectedByAdminID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

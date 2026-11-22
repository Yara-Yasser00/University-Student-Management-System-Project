using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 4 (Registration)
public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("Enrollment");
        builder.HasKey(e => e.EnrollmentID);

        // Columns
        builder.Property(e => e.AttendanceMark).HasPrecision(4, 1);
        builder.Property(e => e.PracticalMark).HasPrecision(4, 1);
        builder.Property(e => e.MidtermMark).HasPrecision(4, 1);
        builder.Property(e => e.OralMark).HasPrecision(4, 1);
        builder.Property(e => e.FinalMark).HasPrecision(4, 1);

        // Unique indexes: a student enrolls in an offering only once.
        builder.HasIndex(e => new { e.StudentID, e.OfferingID }).IsUnique();

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R30: Enrollment.StudentID → Student
        builder.HasOne(e => e.Student)
               .WithMany(p => p.Enrollments)
               .HasForeignKey(e => e.StudentID)
               .OnDelete(DeleteBehavior.Restrict);

        // R30: Enrollment.OfferingID → CourseOffering
        builder.HasOne(e => e.Offering)
               .WithMany(p => p.Enrollments)
               .HasForeignKey(e => e.OfferingID)
               .OnDelete(DeleteBehavior.Restrict);

        // R24: Enrollment.GroupID → ClassGroup
        builder.HasOne(e => e.Group)
               .WithMany(p => p.Enrollments)
               .HasForeignKey(e => e.GroupID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

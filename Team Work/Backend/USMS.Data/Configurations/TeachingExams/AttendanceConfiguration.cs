using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 5 (Teaching & Exams)
public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("Attendance");
        builder.HasKey(e => new { e.SessionID, e.EnrollmentID });

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R27: Attendance.SessionID → ClassSession
        builder.HasOne(e => e.Session)
               .WithMany(p => p.Attendances)
               .HasForeignKey(e => e.SessionID)
               .OnDelete(DeleteBehavior.Restrict);

        // R27: Attendance.EnrollmentID → Enrollment
        builder.HasOne(e => e.Enrollment)
               .WithMany(p => p.Attendances)
               .HasForeignKey(e => e.EnrollmentID)
               .OnDelete(DeleteBehavior.Restrict);

        // R27: Attendance.RecordedByStaffID → Staff
        builder.HasOne(e => e.RecordedByStaff)
               .WithMany(p => p.RecordedAttendances)
               .HasForeignKey(e => e.RecordedByStaffID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 5 (Teaching & Exams): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

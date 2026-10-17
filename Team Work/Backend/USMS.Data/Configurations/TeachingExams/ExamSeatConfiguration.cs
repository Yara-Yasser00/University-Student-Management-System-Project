using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 5 (Teaching & Exams)
public class ExamSeatConfiguration : IEntityTypeConfiguration<ExamSeat>
{
    public void Configure(EntityTypeBuilder<ExamSeat> builder)
    {
        builder.ToTable("ExamSeat");
        builder.HasKey(e => new { e.ExamID, e.EnrollmentID });

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R28: ExamSeat.ExamID → Exam
        builder.HasOne(e => e.Exam)
               .WithMany(p => p.ExamSeats)
               .HasForeignKey(e => e.ExamID)
               .OnDelete(DeleteBehavior.Restrict);

        // R28: ExamSeat.EnrollmentID → Enrollment
        builder.HasOne(e => e.Enrollment)
               .WithMany(p => p.ExamSeats)
               .HasForeignKey(e => e.EnrollmentID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 5 (Teaching & Exams): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

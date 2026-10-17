using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 5 (Teaching & Exams)
public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.ToTable("Exam");
        builder.HasKey(e => e.ExamID);

        // String foreign keys must have the same length as the key they point to.
        builder.Property(e => e.RoomCode).HasMaxLength(30);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R33: Exam.OfferingID → CourseOffering
        builder.HasOne(e => e.Offering)
               .WithMany(p => p.Exams)
               .HasForeignKey(e => e.OfferingID)
               .OnDelete(DeleteBehavior.Restrict);

        // R34: Exam.RoomCode → Room
        builder.HasOne(e => e.Room)
               .WithMany(p => p.Exams)
               .HasForeignKey(e => e.RoomCode)
               .OnDelete(DeleteBehavior.Restrict);

        // R35: Exam.HeadStaffID → Staff
        builder.HasOne(e => e.HeadStaff)
               .WithMany(p => p.HeadedExams)
               .HasForeignKey(e => e.HeadStaffID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 5 (Teaching & Exams): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

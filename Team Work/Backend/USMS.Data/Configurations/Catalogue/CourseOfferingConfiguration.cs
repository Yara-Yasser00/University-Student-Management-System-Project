using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 3 (Catalogue & Schedule)
public class CourseOfferingConfiguration : IEntityTypeConfiguration<CourseOffering>
{
    public void Configure(EntityTypeBuilder<CourseOffering> builder)
    {
        // Check constraint (team decision, 24 November 2026): a returned result must have a reason.
        builder.ToTable("CourseOffering", t => t.HasCheckConstraint(
            "CK_CourseOffering_ReturnReason",
            "[ResultStatus] <> N'Returned' OR ([ReturnReason] IS NOT NULL AND LEN([ReturnReason]) > 0)"));
        builder.HasKey(e => e.OfferingID);

        // String foreign keys must have the same length as the key they point to.
        builder.Property(e => e.LectureRoomCode).HasMaxLength(30);

        // Columns
        builder.Property(e => e.LectureDay).HasConversion<string>().HasMaxLength(3);    // WeekDay
        builder.Property(e => e.ResultStatus).HasConversion<string>().HasMaxLength(10); // ResultStatus
        builder.Property(e => e.ReturnReason).HasMaxLength(300);

        // Unique indexes: a course is offered once per term.
        builder.HasIndex(e => new { e.CourseID, e.TermID }).IsUnique();

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R15: CourseOffering.CourseID → Course
        builder.HasOne(e => e.Course)
               .WithMany(p => p.Offerings)
               .HasForeignKey(e => e.CourseID)
               .OnDelete(DeleteBehavior.Restrict);

        // R16: CourseOffering.TermID → AcademicTerm
        builder.HasOne(e => e.Term)
               .WithMany(p => p.CourseOfferings)
               .HasForeignKey(e => e.TermID)
               .OnDelete(DeleteBehavior.Restrict);

        // R17: CourseOffering.InstructorStaffID → Staff
        builder.HasOne(e => e.InstructorStaff)
               .WithMany(p => p.TaughtOfferings)
               .HasForeignKey(e => e.InstructorStaffID)
               .OnDelete(DeleteBehavior.Restrict);

        // R18: CourseOffering.LectureRoomCode → Room
        builder.HasOne(e => e.LectureRoom)
               .WithMany(p => p.LectureOfferings)
               .HasForeignKey(e => e.LectureRoomCode)
               .OnDelete(DeleteBehavior.Restrict);

        // R29: CourseOffering.ApprovedByAdminID → CollegeAdmin
        builder.HasOne(e => e.ApprovedByAdmin)
               .WithMany(p => p.ApprovedOfferings)
               .HasForeignKey(e => e.ApprovedByAdminID)
               .OnDelete(DeleteBehavior.Restrict);

        // R29: CourseOffering.PublishedByAdminID → CollegeAdmin
        builder.HasOne(e => e.PublishedByAdmin)
               .WithMany(p => p.PublishedOfferings)
               .HasForeignKey(e => e.PublishedByAdminID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

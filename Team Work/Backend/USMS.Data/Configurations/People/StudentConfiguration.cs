using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 2 (People)
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Student", t => t.Property(e => e.PersonID).HasColumnName("StudentID"));

        // String foreign keys must have the same length as the key they point to.
        builder.Property(e => e.CollegeCode).HasMaxLength(10);

        // Columns
        builder.Property(e => e.Level).HasConversion<string>().HasMaxLength(10);            // AcademicLevel
        builder.Property(e => e.AcademicStatus).HasConversion<string>().HasMaxLength(15);   // AcademicStatus
        builder.Property(e => e.GuardianName).HasMaxLength(150);
        builder.Property(e => e.GuardianOccupation).HasMaxLength(100);
        builder.Property(e => e.GuardianMobile).HasMaxLength(20);
        builder.Property(e => e.City).HasMaxLength(50);
        builder.Property(e => e.HomePhone).HasMaxLength(20);
        builder.Property(e => e.CertificateType).HasMaxLength(50);
        builder.Property(e => e.SchoolName).HasMaxLength(150);
        builder.Property(e => e.PreviousScore).HasPrecision(5, 2);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R39 (new): College enrolls Student — Student.CollegeCode → College
        builder.HasOne(e => e.College)
               .WithMany(p => p.Students)
               .HasForeignKey(e => e.CollegeCode)
               .OnDelete(DeleteBehavior.Restrict);

        // R7: Student.DepartmentID → Department (NULL in years 1–2, so Partial on the Student side)
        builder.HasOne(e => e.Department)
               .WithMany(p => p.Students)
               .HasForeignKey(e => e.DepartmentID)
               .OnDelete(DeleteBehavior.Restrict);

        // R9: Student.AdvisorStaffID → Staff
        builder.HasOne(e => e.AdvisorStaff)
               .WithMany(p => p.AdvisedStudents)
               .HasForeignKey(e => e.AdvisorStaffID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

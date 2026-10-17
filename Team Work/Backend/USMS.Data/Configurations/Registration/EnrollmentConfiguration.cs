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

        // TODO Group 4 (Registration): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 3 (Catalogue & Schedule)
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Course");
        builder.HasKey(e => e.CourseID);

        // String foreign keys must have the same length as the key they point to.
        builder.Property(e => e.CollegeCode).HasMaxLength(10);

        // Columns
        builder.Property(e => e.Code).HasMaxLength(10);                                 // e.g. IS 301
        builder.Property(e => e.Name).HasMaxLength(150);
        builder.Property(e => e.Level).HasConversion<string>().HasMaxLength(10);        // AcademicLevel
        builder.Property(e => e.ActivityType).HasConversion<string>().HasMaxLength(10); // ActivityType
        builder.Property(e => e.Status).HasConversion<string>().HasMaxLength(10);       // EntityStatus

        // Unique indexes: the course code is unique within its college.
        builder.HasIndex(e => new { e.CollegeCode, e.Code }).IsUnique();

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R40 (new): College offers Course — Course.CollegeCode → College
        builder.HasOne(e => e.College)
               .WithMany(p => p.Courses)
               .HasForeignKey(e => e.CollegeCode)
               .OnDelete(DeleteBehavior.Restrict);

        // R13 (Course offered to Department, M:N) is configured in DepartmentCourseConfiguration.
    }
}

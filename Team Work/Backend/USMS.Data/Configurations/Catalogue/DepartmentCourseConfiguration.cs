using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 3 (Catalogue & Schedule)
public class DepartmentCourseConfiguration : IEntityTypeConfiguration<DepartmentCourse>
{
    public void Configure(EntityTypeBuilder<DepartmentCourse> builder)
    {
        builder.ToTable("DepartmentCourse");
        builder.HasKey(e => new { e.DepartmentID, e.CourseID });

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R13: Course offered to Department (M:N, Partial on both sides)
        builder.HasOne(e => e.Department)
               .WithMany(p => p.DepartmentCourses)
               .HasForeignKey(e => e.DepartmentID)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Course)
               .WithMany(p => p.DepartmentCourses)
               .HasForeignKey(e => e.CourseID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

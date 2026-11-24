using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 3 (Catalogue & Schedule)
public class CoursePrerequisiteConfiguration : IEntityTypeConfiguration<CoursePrerequisite>
{
    public void Configure(EntityTypeBuilder<CoursePrerequisite> builder)
    {
        // Check constraint (team decision, 24 November 2026): a course is not its own prerequisite.
        builder.ToTable("CoursePrerequisite", t => t.HasCheckConstraint(
            "CK_CoursePrerequisite_NotSelf",
            "[CourseID] <> [PrerequisiteCourseID]"));
        builder.HasKey(e => new { e.CourseID, e.PrerequisiteCourseID });

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R14: CoursePrerequisite.CourseID → Course
        builder.HasOne(e => e.Course)
               .WithMany(p => p.Prerequisites)
               .HasForeignKey(e => e.CourseID)
               .OnDelete(DeleteBehavior.Restrict);

        // R14: CoursePrerequisite.PrerequisiteCourseID → Course
        builder.HasOne(e => e.PrerequisiteCourse)
               .WithMany(p => p.RequiredFor)
               .HasForeignKey(e => e.PrerequisiteCourseID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

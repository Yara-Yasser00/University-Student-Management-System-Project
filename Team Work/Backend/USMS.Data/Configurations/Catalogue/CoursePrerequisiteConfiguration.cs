using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 3 (Catalogue & Schedule)
public class CoursePrerequisiteConfiguration : IEntityTypeConfiguration<CoursePrerequisite>
{
    public void Configure(EntityTypeBuilder<CoursePrerequisite> builder)
    {
        builder.ToTable("CoursePrerequisite");
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

        // TODO Group 3 (Catalogue & Schedule): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

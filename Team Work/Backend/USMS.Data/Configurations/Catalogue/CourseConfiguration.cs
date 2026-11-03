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

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R40 (new): College offers Course — Course.CollegeCode → College
        builder.HasOne(e => e.College)
               .WithMany(p => p.Courses)
               .HasForeignKey(e => e.CollegeCode)
               .OnDelete(DeleteBehavior.Restrict);

        // R13 (Course offered to Department, M:N) is configured in DepartmentCourseConfiguration.

        // TODO Group 3 (Catalogue & Schedule): remaining columns (types, lengths, NULL),
        // unique indexes (Code is unique within the college: CollegeCode + Code),
        // defaults and seed data, as in the ERD.
    }
}

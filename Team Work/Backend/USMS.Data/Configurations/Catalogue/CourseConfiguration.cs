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

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R13: Course.DepartmentID → Department
        builder.HasOne(e => e.Department)
               .WithMany(p => p.Courses)
               .HasForeignKey(e => e.DepartmentID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 3 (Catalogue & Schedule): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

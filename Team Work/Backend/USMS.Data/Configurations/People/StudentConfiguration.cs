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

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R7: Student.DepartmentID → Department
        builder.HasOne(e => e.Department)
               .WithMany(p => p.Students)
               .HasForeignKey(e => e.DepartmentID)
               .OnDelete(DeleteBehavior.Restrict);

        // R9: Student.AdvisorStaffID → Staff
        builder.HasOne(e => e.AdvisorStaff)
               .WithMany(p => p.AdvisedStudents)
               .HasForeignKey(e => e.AdvisorStaffID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 2 (People): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

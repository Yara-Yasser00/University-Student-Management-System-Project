using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 1 (Organisation & Lookups)
public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Department");
        builder.HasKey(e => e.DepartmentID);

        // String foreign keys must have the same length as the key they point to.
        builder.Property(e => e.CollegeCode).HasMaxLength(10);

        // Columns
        builder.Property(e => e.Code).HasMaxLength(10);
        builder.Property(e => e.Name).HasMaxLength(150);
        builder.Property(e => e.Status).HasConversion<string>().HasMaxLength(10);   // EntityStatus

        // Unique indexes: the department code is unique within its college.
        builder.HasIndex(e => new { e.CollegeCode, e.Code }).IsUnique();

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R1: Department.CollegeCode → College
        builder.HasOne(e => e.College)
               .WithMany(p => p.Departments)
               .HasForeignKey(e => e.CollegeCode)
               .OnDelete(DeleteBehavior.Restrict);

        // R2: Department.HeadStaffID → Staff
        builder.HasOne(e => e.HeadStaff)
               .WithOne(p => p.HeadOfDepartment)
               .HasForeignKey<Department>(e => e.HeadStaffID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

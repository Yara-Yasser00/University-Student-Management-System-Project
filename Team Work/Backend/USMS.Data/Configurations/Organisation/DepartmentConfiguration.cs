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

        // TODO Group 1 (Organisation & Lookups): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

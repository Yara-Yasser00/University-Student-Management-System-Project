using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 2 (People)
public class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.ToTable("Staff", t => t.Property(e => e.PersonID).HasColumnName("StaffID"));

        // Columns
        builder.Property(e => e.StaffType).HasConversion<string>().HasMaxLength(20);      // StaffType
        builder.Property(e => e.AcademicRank).HasConversion<string>().HasMaxLength(30);   // AcademicRank
        builder.Property(e => e.Specialization).HasMaxLength(100);
        builder.Property(e => e.Office).HasMaxLength(50);
        builder.Property(e => e.Status).HasConversion<string>().HasMaxLength(10);         // EntityStatus

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R8: Staff.DepartmentID → Department
        builder.HasOne(e => e.Department)
               .WithMany(p => p.StaffMembers)
               .HasForeignKey(e => e.DepartmentID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

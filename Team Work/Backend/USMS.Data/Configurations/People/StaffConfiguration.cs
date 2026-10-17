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

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R8: Staff.DepartmentID → Department
        builder.HasOne(e => e.Department)
               .WithMany(p => p.StaffMembers)
               .HasForeignKey(e => e.DepartmentID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 2 (People): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

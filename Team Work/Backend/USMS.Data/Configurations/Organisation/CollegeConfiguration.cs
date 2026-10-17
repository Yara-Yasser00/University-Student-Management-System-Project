using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 1 (Organisation & Lookups)
public class CollegeConfiguration : IEntityTypeConfiguration<College>
{
    public void Configure(EntityTypeBuilder<College> builder)
    {
        builder.ToTable("College");
        builder.HasKey(e => e.CollegeCode);
        builder.Property(e => e.CollegeCode).HasMaxLength(10);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R3: College.DeanStaffID → Staff
        builder.HasOne(e => e.DeanStaff)
               .WithOne(p => p.DeanOfCollege)
               .HasForeignKey<College>(e => e.DeanStaffID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 1 (Organisation & Lookups): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

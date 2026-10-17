using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 3 (Catalogue & Schedule)
public class ClassGroupConfiguration : IEntityTypeConfiguration<ClassGroup>
{
    public void Configure(EntityTypeBuilder<ClassGroup> builder)
    {
        builder.ToTable("ClassGroup");
        builder.HasKey(e => e.GroupID);

        // String foreign keys must have the same length as the key they point to.
        builder.Property(e => e.RoomCode).HasMaxLength(30);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R19: ClassGroup.OfferingID → CourseOffering
        builder.HasOne(e => e.Offering)
               .WithMany(p => p.ClassGroups)
               .HasForeignKey(e => e.OfferingID)
               .OnDelete(DeleteBehavior.Restrict);

        // R20: ClassGroup.TAStaffID → Staff
        builder.HasOne(e => e.TAStaff)
               .WithMany(p => p.AssistedGroups)
               .HasForeignKey(e => e.TAStaffID)
               .OnDelete(DeleteBehavior.Restrict);

        // R21: ClassGroup.RoomCode → Room
        builder.HasOne(e => e.Room)
               .WithMany(p => p.ClassGroups)
               .HasForeignKey(e => e.RoomCode)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 3 (Catalogue & Schedule): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

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

        // Columns
        builder.Property(e => e.GroupType).HasConversion<string>().HasMaxLength(10);    // GroupType
        builder.Property(e => e.Day).HasConversion<string>().HasMaxLength(3);           // WeekDay

        // Unique indexes: the group number is unique within the offering.
        builder.HasIndex(e => new { e.OfferingID, e.GroupNumber }).IsUnique();

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
    }
}

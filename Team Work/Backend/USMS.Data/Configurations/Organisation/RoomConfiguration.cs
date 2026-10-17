using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 1 (Organisation & Lookups)
public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Room");
        builder.HasKey(e => e.RoomCode);
        builder.Property(e => e.RoomCode).HasMaxLength(30);

        // String foreign keys must have the same length as the key they point to.
        builder.Property(e => e.CollegeCode).HasMaxLength(10);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R4: Room.CollegeCode → College
        builder.HasOne(e => e.College)
               .WithMany(p => p.Rooms)
               .HasForeignKey(e => e.CollegeCode)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 1 (Organisation & Lookups): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

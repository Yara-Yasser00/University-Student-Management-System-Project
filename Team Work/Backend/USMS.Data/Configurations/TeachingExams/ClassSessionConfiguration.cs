using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 5 (Teaching & Exams)
public class ClassSessionConfiguration : IEntityTypeConfiguration<ClassSession>
{
    public void Configure(EntityTypeBuilder<ClassSession> builder)
    {
        builder.ToTable("ClassSession");
        builder.HasKey(e => e.SessionID);

        // Unique index (team decision, 24 November 2026): a session number is not repeated
        // for the same offering and group. HasFilter(null) keeps lecture sessions (GroupID NULL)
        // inside the index; without it EF adds "[GroupID] IS NOT NULL" and skips them.
        builder.HasIndex(e => new { e.OfferingID, e.GroupID, e.SessionNumber })
               .IsUnique()
               .HasFilter(null);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R31: ClassSession.OfferingID → CourseOffering
        builder.HasOne(e => e.Offering)
               .WithMany(p => p.ClassSessions)
               .HasForeignKey(e => e.OfferingID)
               .OnDelete(DeleteBehavior.Restrict);

        // R32: ClassSession.GroupID → ClassGroup
        builder.HasOne(e => e.Group)
               .WithMany(p => p.ClassSessions)
               .HasForeignKey(e => e.GroupID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

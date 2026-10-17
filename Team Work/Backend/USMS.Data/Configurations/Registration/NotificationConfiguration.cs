using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 4 (Registration)
public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notification");
        builder.HasKey(e => e.NotificationID);

        // String foreign keys must have the same length as the key they point to.
        builder.Property(e => e.LoginID).HasMaxLength(20);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R38: Notification.LoginID → UserAccount
        builder.HasOne(e => e.UserAccount)
               .WithMany(p => p.Notifications)
               .HasForeignKey(e => e.LoginID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 4 (Registration): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

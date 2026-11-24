using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 1 (Organisation & Lookups)
public class PermissionChangeLogConfiguration : IEntityTypeConfiguration<PermissionChangeLog>
{
    public void Configure(EntityTypeBuilder<PermissionChangeLog> builder)
    {
        builder.ToTable("PermissionChangeLog");
        builder.HasKey(e => e.ChangeID);

        // String foreign keys must have the same length as the key they point to.
        builder.Property(e => e.PermissionKey).HasMaxLength(60);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R43: PermissionChangeLog.PermissionKey → Permission
        builder.HasOne(e => e.Permission)
               .WithMany(p => p.ChangeLogs)
               .HasForeignKey(e => e.PermissionKey)
               .OnDelete(DeleteBehavior.Restrict);

        // R44: PermissionChangeLog.ChangedByAdminID → UniversityAdmin
        builder.HasOne(e => e.ChangedByAdmin)
               .WithMany(p => p.PermissionChanges)
               .HasForeignKey(e => e.ChangedByAdminID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 1 (Organisation & Lookups)
public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permission");
        builder.HasKey(e => e.PermissionKey);
        builder.Property(e => e.PermissionKey).HasMaxLength(60);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R37: Permission.UpdatedByAdminID → UniversityAdmin
        builder.HasOne(e => e.UpdatedByAdmin)
               .WithMany(p => p.UpdatedPermissions)
               .HasForeignKey(e => e.UpdatedByAdminID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 1 (Organisation & Lookups): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

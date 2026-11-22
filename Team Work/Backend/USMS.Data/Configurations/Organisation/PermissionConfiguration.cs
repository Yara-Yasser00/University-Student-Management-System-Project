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

        // Columns
        builder.Property(e => e.Role).HasConversion<string>().HasMaxLength(20);     // UserRole
        builder.Property(e => e.GroupName).HasMaxLength(30);
        builder.Property(e => e.Label).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(300);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R37: Permission.UpdatedByAdminID → UniversityAdmin
        builder.HasOne(e => e.UpdatedByAdmin)
               .WithMany(p => p.UpdatedPermissions)
               .HasForeignKey(e => e.UpdatedByAdminID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 2 (People)
public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.ToTable("UserAccount");
        builder.HasKey(e => e.LoginID);
        builder.Property(e => e.LoginID).HasMaxLength(20);

        // Columns
        builder.Property(e => e.Email).HasMaxLength(150);
        builder.Property(e => e.PasswordHash).HasMaxLength(255);
        builder.Property(e => e.Role).HasConversion<string>().HasMaxLength(20);     // UserRole
        builder.Property(e => e.Status).HasConversion<string>().HasMaxLength(10);   // EntityStatus

        // Unique indexes (PersonID is already unique through the 1 : 1 relationship below)
        builder.HasIndex(e => e.Email).IsUnique();

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R6: UserAccount.PersonID → Person
        builder.HasOne(e => e.Person)
               .WithOne(p => p.UserAccount)
               .HasForeignKey<UserAccount>(e => e.PersonID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

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

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R6: UserAccount.PersonID → Person
        builder.HasOne(e => e.Person)
               .WithOne(p => p.UserAccount)
               .HasForeignKey<UserAccount>(e => e.PersonID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 2 (People): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

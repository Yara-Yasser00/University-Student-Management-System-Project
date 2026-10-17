using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 2 (People)
public class CollegeAdminConfiguration : IEntityTypeConfiguration<CollegeAdmin>
{
    public void Configure(EntityTypeBuilder<CollegeAdmin> builder)
    {
        builder.ToTable("CollegeAdmin", t => t.Property(e => e.PersonID).HasColumnName("AdminID"));

        // String foreign keys must have the same length as the key they point to.
        builder.Property(e => e.CollegeCode).HasMaxLength(10);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R10: CollegeAdmin.CollegeCode → College
        builder.HasOne(e => e.College)
               .WithMany(p => p.CollegeAdmins)
               .HasForeignKey(e => e.CollegeCode)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 2 (People): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

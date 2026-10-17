using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 2 (People)
public class UniversityAdminConfiguration : IEntityTypeConfiguration<UniversityAdmin>
{
    public void Configure(EntityTypeBuilder<UniversityAdmin> builder)
    {
        builder.ToTable("UniversityAdmin", t => t.Property(e => e.PersonID).HasColumnName("AdminID"));

        // TODO Group 2 (People): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

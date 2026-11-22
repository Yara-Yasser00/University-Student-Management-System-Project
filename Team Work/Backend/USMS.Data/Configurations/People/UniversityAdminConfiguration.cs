using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 2 (People)
public class UniversityAdminConfiguration : IEntityTypeConfiguration<UniversityAdmin>
{
    public void Configure(EntityTypeBuilder<UniversityAdmin> builder)
    {
        // The ERD gives this table only its key (AdminID), so there is nothing else to configure.
        builder.ToTable("UniversityAdmin", t => t.Property(e => e.PersonID).HasColumnName("AdminID"));
    }
}

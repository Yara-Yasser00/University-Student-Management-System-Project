using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 2 (People)
public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admin", t => t.Property(e => e.PersonID).HasColumnName("AdminID"));

        // Columns
        builder.Property(e => e.AdminType).HasConversion<string>().HasMaxLength(10);   // AdminType
    }
}

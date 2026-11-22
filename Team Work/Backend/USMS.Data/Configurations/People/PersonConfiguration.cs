using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 2 (People)
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");
        builder.HasKey(e => e.PersonID);

        // Person → Student / Staff / Admin, and Admin → UniversityAdmin / CollegeAdmin:
        // each class gets its own table that shares the same key (TPT).
        builder.UseTptMappingStrategy();

        // Columns
        builder.Property(e => e.NameEn).HasMaxLength(150);
        builder.Property(e => e.NameAr).HasMaxLength(150);
        builder.Property(e => e.Gender).HasMaxLength(10);
        builder.Property(e => e.Nationality).HasMaxLength(50);
        builder.Property(e => e.NationalID).HasMaxLength(14);
        builder.Property(e => e.PlaceOfBirth).HasMaxLength(100);
        builder.Property(e => e.Mobile).HasMaxLength(20);
        builder.Property(e => e.Address).HasMaxLength(250);
        builder.Property(e => e.EmergencyName).HasMaxLength(150);
        builder.Property(e => e.EmergencyPhone).HasMaxLength(20);

        // Unique indexes
        builder.HasIndex(e => e.NationalID).IsUnique();
    }
}

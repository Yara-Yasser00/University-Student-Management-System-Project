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

        // TODO Group 2 (People): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 3 (Catalogue & Schedule)
public class AcademicTermConfiguration : IEntityTypeConfiguration<AcademicTerm>
{
    public void Configure(EntityTypeBuilder<AcademicTerm> builder)
    {
        builder.ToTable("AcademicTerm");
        builder.HasKey(e => e.TermID);

        // TODO Group 3 (Catalogue & Schedule): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

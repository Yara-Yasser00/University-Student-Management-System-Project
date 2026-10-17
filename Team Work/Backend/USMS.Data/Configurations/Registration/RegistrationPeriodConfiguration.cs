using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 4 (Registration)
public class RegistrationPeriodConfiguration : IEntityTypeConfiguration<RegistrationPeriod>
{
    public void Configure(EntityTypeBuilder<RegistrationPeriod> builder)
    {
        builder.ToTable("RegistrationPeriod");
        builder.HasKey(e => new { e.CollegeCode, e.TermID });
        builder.Property(e => e.CollegeCode).HasMaxLength(10);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R23: RegistrationPeriod.CollegeCode → College
        builder.HasOne(e => e.College)
               .WithMany(p => p.RegistrationPeriods)
               .HasForeignKey(e => e.CollegeCode)
               .OnDelete(DeleteBehavior.Restrict);

        // R23: RegistrationPeriod.TermID → AcademicTerm
        builder.HasOne(e => e.Term)
               .WithMany(p => p.RegistrationPeriods)
               .HasForeignKey(e => e.TermID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 4 (Registration): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

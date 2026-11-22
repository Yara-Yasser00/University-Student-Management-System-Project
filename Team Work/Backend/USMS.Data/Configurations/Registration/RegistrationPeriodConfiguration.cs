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

        // Columns
        builder.Property(e => e.ManualOverride).HasConversion<string>().HasMaxLength(15); // ManualOverride

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
    }
}

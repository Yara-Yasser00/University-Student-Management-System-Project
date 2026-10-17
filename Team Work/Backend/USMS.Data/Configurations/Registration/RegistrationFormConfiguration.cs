using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 4 (Registration)
public class RegistrationFormConfiguration : IEntityTypeConfiguration<RegistrationForm>
{
    public void Configure(EntityTypeBuilder<RegistrationForm> builder)
    {
        builder.ToTable("RegistrationForm");
        builder.HasKey(e => e.FormID);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R25: RegistrationForm.StudentID → Student
        builder.HasOne(e => e.Student)
               .WithMany(p => p.RegistrationForms)
               .HasForeignKey(e => e.StudentID)
               .OnDelete(DeleteBehavior.Restrict);

        // R25: RegistrationForm.TermID → AcademicTerm
        builder.HasOne(e => e.Term)
               .WithMany(p => p.RegistrationForms)
               .HasForeignKey(e => e.TermID)
               .OnDelete(DeleteBehavior.Restrict);

        // R26: RegistrationForm.AdvisorStaffID → Staff
        builder.HasOne(e => e.AdvisorStaff)
               .WithMany(p => p.ReviewedRegistrationForms)
               .HasForeignKey(e => e.AdvisorStaffID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 4 (Registration): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

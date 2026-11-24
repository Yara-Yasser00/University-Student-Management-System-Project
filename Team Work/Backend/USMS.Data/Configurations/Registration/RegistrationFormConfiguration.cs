using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 4 (Registration)
public class RegistrationFormConfiguration : IEntityTypeConfiguration<RegistrationForm>
{
    public void Configure(EntityTypeBuilder<RegistrationForm> builder)
    {
        // Check constraint (team decision, 24 November 2026): a change request must have a note.
        builder.ToTable("RegistrationForm", t => t.HasCheckConstraint(
            "CK_RegistrationForm_AdvisorNote",
            "[Decision] <> N'ChangesRequested' OR ([AdvisorNote] IS NOT NULL AND LEN([AdvisorNote]) > 0)"));
        builder.HasKey(e => e.FormID);

        // Columns
        builder.Property(e => e.Decision).HasConversion<string>().HasMaxLength(20);     // AdvisorDecision
        builder.Property(e => e.AdvisorNote).HasMaxLength(500);

        // Unique indexes: one registration form per student per term.
        builder.HasIndex(e => new { e.StudentID, e.TermID }).IsUnique();

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
    }
}

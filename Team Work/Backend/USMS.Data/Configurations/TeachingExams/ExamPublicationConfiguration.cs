using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 5 (Teaching & Exams)
public class ExamPublicationConfiguration : IEntityTypeConfiguration<ExamPublication>
{
    public void Configure(EntityTypeBuilder<ExamPublication> builder)
    {
        builder.ToTable("ExamPublication");
        builder.HasKey(e => new { e.CollegeCode, e.TermID, e.ExamType });
        builder.Property(e => e.CollegeCode).HasMaxLength(10);
        builder.Property(e => e.ExamType).HasConversion<string>().HasMaxLength(10);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R36: ExamPublication.CollegeCode → College
        builder.HasOne(e => e.College)
               .WithMany(p => p.ExamPublications)
               .HasForeignKey(e => e.CollegeCode)
               .OnDelete(DeleteBehavior.Restrict);

        // R36: ExamPublication.TermID → AcademicTerm
        builder.HasOne(e => e.Term)
               .WithMany(p => p.ExamPublications)
               .HasForeignKey(e => e.TermID)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 5 (Teaching & Exams): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 1 (Organisation & Lookups)
public class CollegeConfiguration : IEntityTypeConfiguration<College>
{
    public void Configure(EntityTypeBuilder<College> builder)
    {
        builder.ToTable("College");
        builder.HasKey(e => e.CollegeCode);
        builder.Property(e => e.CollegeCode).HasMaxLength(10);

        // Columns
        builder.Property(e => e.NameEn).HasMaxLength(150);
        builder.Property(e => e.NameAr).HasMaxLength(150);
        builder.Property(e => e.LogoUrl).HasMaxLength(300);
        builder.Property(e => e.PhotoUrl).HasMaxLength(300);
        builder.Property(e => e.Status).HasConversion<string>().HasMaxLength(10);   // EntityStatus

        // Default values (from the ERD)
        builder.Property(e => e.SophomoreCredits).HasDefaultValue((byte)30);
        builder.Property(e => e.JuniorCredits).HasDefaultValue((byte)72);
        builder.Property(e => e.SeniorCredits).HasDefaultValue((byte)108);
        builder.Property(e => e.GraduationCredits).HasDefaultValue((byte)132);
        builder.Property(e => e.AttendanceWarningPct).HasDefaultValue((byte)75);
        builder.Property(e => e.ExamDeprivationPct).HasDefaultValue((byte)65);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R3: College.DeanStaffID → Staff
        builder.HasOne(e => e.DeanStaff)
               .WithOne(p => p.DeanOfCollege)
               .HasForeignKey<College>(e => e.DeanStaffID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

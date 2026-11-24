using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;
using USMS.Data.Enums;

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

        // Seed data (fixed lookup values, agreed by the team)
        // Names: UI-UX prototype (university-pages.tsx). Years: agreed by the team. The dean is set by the test data / the system.
        builder.HasData(
            new College
            {
                CollegeCode = "FCAI",
                NameEn = "Faculty of Computers & Artificial Intelligence",
                NameAr = "كلية الحاسبات والذكاء الاصطناعي",
                EstablishedYear = 2020,
                DeanStaffID = null,
                LogoUrl = "img/logo-fcai.png",
                PhotoUrl = "img/fcai.jpg",
                Status = EntityStatus.Active,
                SophomoreCredits = 30,
                JuniorCredits = 72,
                SeniorCredits = 108,
                GraduationCredits = 132,
                AttendanceWarningPct = 75,
                ExamDeprivationPct = 65
            },
            new College
            {
                CollegeCode = "EDU",
                NameEn = "Faculty of Education",
                NameAr = "كلية التربية",
                EstablishedYear = 1995,
                DeanStaffID = null,
                LogoUrl = "img/logo-edu.png",
                PhotoUrl = "img/edu.jpg",
                Status = EntityStatus.Active,
                SophomoreCredits = 30,
                JuniorCredits = 72,
                SeniorCredits = 108,
                GraduationCredits = 132,
                AttendanceWarningPct = 75,
                ExamDeprivationPct = 65
            },
            new College
            {
                CollegeCode = "ALS",
                NameEn = "Faculty of Al-Alsun (Languages)",
                NameAr = "كلية الألسن",
                EstablishedYear = 2021,
                DeanStaffID = null,
                LogoUrl = "img/logo-als.png",
                PhotoUrl = "img/als.jpg",
                Status = EntityStatus.Active,
                SophomoreCredits = 30,
                JuniorCredits = 72,
                SeniorCredits = 108,
                GraduationCredits = 132,
                AttendanceWarningPct = 75,
                ExamDeprivationPct = 65
            },
            new College
            {
                CollegeCode = "SCI",
                NameEn = "Faculty of Science",
                NameAr = "كلية العلوم",
                EstablishedYear = 2026,
                DeanStaffID = null,
                LogoUrl = "img/logo-sci.png",
                PhotoUrl = "img/sci.jpg",
                Status = EntityStatus.Active,
                SophomoreCredits = 30,
                JuniorCredits = 72,
                SeniorCredits = 108,
                GraduationCredits = 132,
                AttendanceWarningPct = 75,
                ExamDeprivationPct = 65
            },
            new College
            {
                CollegeCode = "TH",
                NameEn = "Faculty of Tourism & Hotels",
                NameAr = "كلية السياحة والفنادق",
                EstablishedYear = 2024,
                DeanStaffID = null,
                LogoUrl = "img/logo-th.png",
                PhotoUrl = "img/th.jpg",
                Status = EntityStatus.Active,
                SophomoreCredits = 30,
                JuniorCredits = 72,
                SeniorCredits = 108,
                GraduationCredits = 132,
                AttendanceWarningPct = 75,
                ExamDeprivationPct = 65
            });
    }
}

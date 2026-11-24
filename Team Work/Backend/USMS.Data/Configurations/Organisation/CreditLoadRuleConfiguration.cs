using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;

namespace USMS.Data.Configurations;

// Owner: Group 1 (Organisation & Lookups)
public class CreditLoadRuleConfiguration : IEntityTypeConfiguration<CreditLoadRule>
{
    public void Configure(EntityTypeBuilder<CreditLoadRule> builder)
    {
        builder.ToTable("CreditLoadRule");
        builder.HasKey(e => e.RuleID);

        // String foreign keys must have the same length as the key they point to.
        builder.Property(e => e.CollegeCode).HasMaxLength(10);

        // Columns
        builder.Property(e => e.MinGPA).HasPrecision(3, 2);
        builder.Property(e => e.MaxGPA).HasPrecision(3, 2);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R5: CreditLoadRule.CollegeCode → College
        builder.HasOne(e => e.College)
               .WithMany(p => p.CreditLoadRules)
               .HasForeignKey(e => e.CollegeCode)
               .OnDelete(DeleteBehavior.Restrict);

        // Seed data (fixed lookup values, agreed by the team)
        // Same three GPA bands for every college (UI-UX Reference, section 3). RuleID 1–15.
        builder.HasData(
            new CreditLoadRule { RuleID = 1, CollegeCode = "FCAI", MinGPA = 0.00m, MaxGPA = 1.99m, MaxCreditHours = 12 },
            new CreditLoadRule { RuleID = 2, CollegeCode = "FCAI", MinGPA = 2.00m, MaxGPA = 2.99m, MaxCreditHours = 18 },
            new CreditLoadRule { RuleID = 3, CollegeCode = "FCAI", MinGPA = 3.00m, MaxGPA = 4.00m, MaxCreditHours = 21 },
            new CreditLoadRule { RuleID = 4, CollegeCode = "EDU", MinGPA = 0.00m, MaxGPA = 1.99m, MaxCreditHours = 12 },
            new CreditLoadRule { RuleID = 5, CollegeCode = "EDU", MinGPA = 2.00m, MaxGPA = 2.99m, MaxCreditHours = 18 },
            new CreditLoadRule { RuleID = 6, CollegeCode = "EDU", MinGPA = 3.00m, MaxGPA = 4.00m, MaxCreditHours = 21 },
            new CreditLoadRule { RuleID = 7, CollegeCode = "ALS", MinGPA = 0.00m, MaxGPA = 1.99m, MaxCreditHours = 12 },
            new CreditLoadRule { RuleID = 8, CollegeCode = "ALS", MinGPA = 2.00m, MaxGPA = 2.99m, MaxCreditHours = 18 },
            new CreditLoadRule { RuleID = 9, CollegeCode = "ALS", MinGPA = 3.00m, MaxGPA = 4.00m, MaxCreditHours = 21 },
            new CreditLoadRule { RuleID = 10, CollegeCode = "SCI", MinGPA = 0.00m, MaxGPA = 1.99m, MaxCreditHours = 12 },
            new CreditLoadRule { RuleID = 11, CollegeCode = "SCI", MinGPA = 2.00m, MaxGPA = 2.99m, MaxCreditHours = 18 },
            new CreditLoadRule { RuleID = 12, CollegeCode = "SCI", MinGPA = 3.00m, MaxGPA = 4.00m, MaxCreditHours = 21 },
            new CreditLoadRule { RuleID = 13, CollegeCode = "TH", MinGPA = 0.00m, MaxGPA = 1.99m, MaxCreditHours = 12 },
            new CreditLoadRule { RuleID = 14, CollegeCode = "TH", MinGPA = 2.00m, MaxGPA = 2.99m, MaxCreditHours = 18 },
            new CreditLoadRule { RuleID = 15, CollegeCode = "TH", MinGPA = 3.00m, MaxGPA = 4.00m, MaxCreditHours = 21 });
    }
}

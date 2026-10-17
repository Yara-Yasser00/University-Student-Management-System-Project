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

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R5: CreditLoadRule.CollegeCode → College
        builder.HasOne(e => e.College)
               .WithMany(p => p.CreditLoadRules)
               .HasForeignKey(e => e.CollegeCode)
               .OnDelete(DeleteBehavior.Restrict);

        // TODO Group 1 (Organisation & Lookups): remaining columns (types, lengths, NULL),
        // unique indexes, defaults and seed data, as in the ERD.
    }
}

namespace USMS.Data.Entities;

// Owner: Group 1 (Organisation & Lookups)
// Table: CreditLoadRule — see "USMS - Database Design Documentation", section 5.
public class CreditLoadRule
{
    // Primary key
    public int RuleID { get; set; }

    // Foreign keys
    public string CollegeCode { get; set; } = null!;

    // TODO Group 1 (Organisation & Lookups): add the remaining columns from the ERD.

    // Navigation properties
    public College College { get; set; } = null!;
}

namespace USMS.Data.Entities;

// Owner: Group 1 (Organisation & Lookups)
// Table: CreditLoadRule — see "USMS - Database Design Documentation", section 5.
public class CreditLoadRule
{
    // Primary key
    public int RuleID { get; set; }

    // Foreign keys
    public string CollegeCode { get; set; } = null!;

    // Columns
    public decimal MinGPA { get; set; }
    public decimal MaxGPA { get; set; }
    public byte MaxCreditHours { get; set; }

    // Navigation properties
    public College College { get; set; } = null!;
}

using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 4 (Registration)
// Table: RegistrationPeriod — see "USMS - Database Design Documentation", section 5.
public class RegistrationPeriod
{
    // Primary key
    public string CollegeCode { get; set; } = null!;
    public int TermID { get; set; }

    // Columns
    public DateTime RegistrationOpens { get; set; }
    public DateTime RegistrationCloses { get; set; }
    public ManualOverride ManualOverride { get; set; }

    // Navigation properties
    public College College { get; set; } = null!;
    public AcademicTerm Term { get; set; } = null!;
}

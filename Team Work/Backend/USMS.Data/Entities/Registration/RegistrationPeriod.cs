namespace USMS.Data.Entities;

// Owner: Group 4 (Registration)
// Table: RegistrationPeriod — see "USMS - Database Design Documentation", section 5.
public class RegistrationPeriod
{
    // Primary key
    public string CollegeCode { get; set; } = null!;
    public int TermID { get; set; }

    // TODO Group 4 (Registration): add the remaining columns from the ERD.

    // Navigation properties
    public College College { get; set; } = null!;
    public AcademicTerm Term { get; set; } = null!;
}

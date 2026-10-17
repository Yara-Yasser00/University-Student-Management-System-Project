namespace USMS.Data.Entities;

// Owner: Group 3 (Catalogue & Schedule)
// Table: SchedulePublication — see "USMS - Database Design Documentation", section 5.
public class SchedulePublication
{
    // Primary key
    public string CollegeCode { get; set; } = null!;
    public int TermID { get; set; }
    public string Level { get; set; } = null!;

    // TODO Group 3 (Catalogue & Schedule): add the remaining columns from the ERD.

    // Navigation properties
    public College College { get; set; } = null!;
    public AcademicTerm Term { get; set; } = null!;
}

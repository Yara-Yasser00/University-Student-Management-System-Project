using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 3 (Catalogue & Schedule)
// Table: SchedulePublication — see "USMS - Database Design Documentation", section 5.
public class SchedulePublication
{
    // Primary key
    public string CollegeCode { get; set; } = null!;
    public int TermID { get; set; }
    public AcademicLevel Level { get; set; }

    // Columns
    public PublicationStatus Status { get; set; }
    public DateTime? PublishedAt { get; set; }

    // Navigation properties
    public College College { get; set; } = null!;
    public AcademicTerm Term { get; set; } = null!;
}

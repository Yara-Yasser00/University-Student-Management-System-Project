using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 4 (Registration)
// Table: RegistrationForm — see "USMS - Database Design Documentation", section 5.
public class RegistrationForm
{
    // Primary key
    public int FormID { get; set; }

    // Foreign keys
    public int StudentID { get; set; }
    public int TermID { get; set; }
    public int? AdvisorStaffID { get; set; }

    // Columns
    public DateTime SavedAt { get; set; }
    public AdvisorDecision Decision { get; set; }
    public string? AdvisorNote { get; set; }
    public DateTime? DecidedAt { get; set; }

    // Navigation properties
    public Student Student { get; set; } = null!;
    public AcademicTerm Term { get; set; } = null!;
    public Staff? AdvisorStaff { get; set; }
}

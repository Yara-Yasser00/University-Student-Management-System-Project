using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 4 (Registration)
// Table: GradeCorrection — added 24 November 2026 (see the rules doc, section 9.2).
// One row each time a College Admin corrects a mark after the results were submitted.
public class GradeCorrection
{
    // Primary key
    public int CorrectionID { get; set; }

    // Foreign keys
    public int EnrollmentID { get; set; }
    public int CorrectedByAdminID { get; set; }

    // Columns
    public GradeComponent Component { get; set; }
    public decimal? OldMark { get; set; }          // NULL if the mark was empty before
    public decimal NewMark { get; set; }
    public string Reason { get; set; } = null!;
    public DateTime CorrectedAt { get; set; }

    // Navigation properties
    public Enrollment Enrollment { get; set; } = null!;
    public CollegeAdmin CorrectedByAdmin { get; set; } = null!;
}

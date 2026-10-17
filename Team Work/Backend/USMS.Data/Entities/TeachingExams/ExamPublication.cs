using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 5 (Teaching & Exams)
// Table: ExamPublication — see "USMS - Database Design Documentation", section 5.
public class ExamPublication
{
    // Primary key
    public string CollegeCode { get; set; } = null!;
    public int TermID { get; set; }
    public ExamType ExamType { get; set; }

    // TODO Group 5 (Teaching & Exams): add the remaining columns from the ERD.

    // Navigation properties
    public College College { get; set; } = null!;
    public AcademicTerm Term { get; set; } = null!;
}

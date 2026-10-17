namespace USMS.Data.Entities;

// Owner: Group 5 (Teaching & Exams)
// Table: ExamSeat — see "USMS - Database Design Documentation", section 5.
public class ExamSeat
{
    // Primary key
    public int ExamID { get; set; }
    public int EnrollmentID { get; set; }

    // TODO Group 5 (Teaching & Exams): add the remaining columns from the ERD.

    // Navigation properties
    public Exam Exam { get; set; } = null!;
    public Enrollment Enrollment { get; set; } = null!;
}

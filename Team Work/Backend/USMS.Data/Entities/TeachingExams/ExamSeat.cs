namespace USMS.Data.Entities;

// Owner: Group 5 (Teaching & Exams)
// Table: ExamSeat — see "USMS - Database Design Documentation", section 5.
public class ExamSeat
{
    // Primary key
    public int ExamID { get; set; }
    public int EnrollmentID { get; set; }

    // Columns
    public string SeatNumber { get; set; } = null!;

    // Navigation properties
    public Exam Exam { get; set; } = null!;
    public Enrollment Enrollment { get; set; } = null!;
}

namespace USMS.Data.Entities;

// Owner: Group 5 (Teaching & Exams)
// Table: Attendance — see "USMS - Database Design Documentation", section 5.
public class Attendance
{
    // Primary key
    public int SessionID { get; set; }
    public int EnrollmentID { get; set; }

    // Foreign keys
    public int RecordedByStaffID { get; set; }

    // TODO Group 5 (Teaching & Exams): add the remaining columns from the ERD.

    // Navigation properties
    public ClassSession Session { get; set; } = null!;
    public Enrollment Enrollment { get; set; } = null!;
    public Staff RecordedByStaff { get; set; } = null!;
}

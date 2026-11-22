using USMS.Data.Enums;

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

    // Columns
    public AttendanceStatus Status { get; set; }
    public DateTime RecordedAt { get; set; }

    // Navigation properties
    public ClassSession Session { get; set; } = null!;
    public Enrollment Enrollment { get; set; } = null!;
    public Staff RecordedByStaff { get; set; } = null!;
}

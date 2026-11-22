using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 5 (Teaching & Exams)
// Table: Exam — see "USMS - Database Design Documentation", section 5.
public class Exam
{
    // Primary key
    public int ExamID { get; set; }

    // Foreign keys
    public int OfferingID { get; set; }
    public string RoomCode { get; set; } = null!;
    public int HeadStaffID { get; set; }

    // Columns
    public ExamType ExamType { get; set; }
    public DateOnly ExamDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string CommitteeName { get; set; } = null!;

    // Navigation properties
    public CourseOffering Offering { get; set; } = null!;
    public Room Room { get; set; } = null!;
    public Staff HeadStaff { get; set; } = null!;
    public ICollection<ExamSeat> ExamSeats { get; set; } = new List<ExamSeat>();
}

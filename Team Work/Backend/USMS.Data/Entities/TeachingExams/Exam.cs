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

    // TODO Group 5 (Teaching & Exams): add the remaining columns from the ERD.

    // Navigation properties
    public CourseOffering Offering { get; set; } = null!;
    public Room Room { get; set; } = null!;
    public Staff HeadStaff { get; set; } = null!;
    public ICollection<ExamSeat> ExamSeats { get; set; } = new List<ExamSeat>();
}

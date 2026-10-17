namespace USMS.Data.Entities;

// Owner: Group 4 (Registration)
// Table: Enrollment — see "USMS - Database Design Documentation", section 5.
public class Enrollment
{
    // Primary key
    public int EnrollmentID { get; set; }

    // Foreign keys
    public int StudentID { get; set; }
    public int OfferingID { get; set; }
    public int? GroupID { get; set; }

    // TODO Group 4 (Registration): add the remaining columns from the ERD.

    // Navigation properties
    public Student Student { get; set; } = null!;
    public CourseOffering Offering { get; set; } = null!;
    public ClassGroup? Group { get; set; }
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public ICollection<ExamSeat> ExamSeats { get; set; } = new List<ExamSeat>();
}

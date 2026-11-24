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

    // Columns
    public DateTime RegisteredAt { get; set; }

    // Marks (NULL until entered by the instructor).
    public decimal? AttendanceMark { get; set; }   // out of 10
    public decimal? PracticalMark { get; set; }    // out of 20
    public decimal? MidtermMark { get; set; }      // out of 30
    public decimal? OralMark { get; set; }         // out of 10
    public decimal? FinalMark { get; set; }        // out of 30

    // Navigation properties
    public Student Student { get; set; } = null!;
    public CourseOffering Offering { get; set; } = null!;
    public ClassGroup? Group { get; set; }
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public ICollection<ExamSeat> ExamSeats { get; set; } = new List<ExamSeat>();
    public ICollection<GradeCorrection> GradeCorrections { get; set; } = new List<GradeCorrection>();
}

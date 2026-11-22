namespace USMS.Data.Entities;

// Owner: Group 5 (Teaching & Exams)
// Table: ClassSession — see "USMS - Database Design Documentation", section 5.
public class ClassSession
{
    // Primary key
    public int SessionID { get; set; }

    // Foreign keys
    public int OfferingID { get; set; }
    public int? GroupID { get; set; }

    // Columns
    public byte SessionNumber { get; set; }
    public DateOnly SessionDate { get; set; }

    // Navigation properties
    public CourseOffering Offering { get; set; } = null!;
    public ClassGroup? Group { get; set; }
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}

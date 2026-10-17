namespace USMS.Data.Entities;

// Owner: Group 3 (Catalogue & Schedule)
// Table: CourseOffering — see "USMS - Database Design Documentation", section 5.
public class CourseOffering
{
    // Primary key
    public int OfferingID { get; set; }

    // Foreign keys
    public int CourseID { get; set; }
    public int TermID { get; set; }
    public int InstructorStaffID { get; set; }
    public string LectureRoomCode { get; set; } = null!;
    public int? ApprovedByAdminID { get; set; }
    public int? PublishedByAdminID { get; set; }

    // TODO Group 3 (Catalogue & Schedule): add the remaining columns from the ERD.

    // Navigation properties
    public Course Course { get; set; } = null!;
    public AcademicTerm Term { get; set; } = null!;
    public Staff InstructorStaff { get; set; } = null!;
    public Room LectureRoom { get; set; } = null!;
    public CollegeAdmin? ApprovedByAdmin { get; set; }
    public CollegeAdmin? PublishedByAdmin { get; set; }
    public ICollection<ClassGroup> ClassGroups { get; set; } = new List<ClassGroup>();
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<ClassSession> ClassSessions { get; set; } = new List<ClassSession>();
    public ICollection<Exam> Exams { get; set; } = new List<Exam>();
}

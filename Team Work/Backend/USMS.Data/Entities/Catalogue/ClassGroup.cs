namespace USMS.Data.Entities;

// Owner: Group 3 (Catalogue & Schedule)
// Table: ClassGroup — see "USMS - Database Design Documentation", section 5.
public class ClassGroup
{
    // Primary key
    public int GroupID { get; set; }

    // Foreign keys
    public int OfferingID { get; set; }
    public int TAStaffID { get; set; }
    public string RoomCode { get; set; } = null!;

    // TODO Group 3 (Catalogue & Schedule): add the remaining columns from the ERD.

    // Navigation properties
    public CourseOffering Offering { get; set; } = null!;
    public Staff TAStaff { get; set; } = null!;
    public Room Room { get; set; } = null!;
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<ClassSession> ClassSessions { get; set; } = new List<ClassSession>();
}

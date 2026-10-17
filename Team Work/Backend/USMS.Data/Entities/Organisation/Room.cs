namespace USMS.Data.Entities;

// Owner: Group 1 (Organisation & Lookups)
// Table: Room — see "USMS - Database Design Documentation", section 5.
public class Room
{
    // Primary key
    public string RoomCode { get; set; } = null!;

    // Foreign keys
    public string? CollegeCode { get; set; }

    // TODO Group 1 (Organisation & Lookups): add the remaining columns from the ERD.

    // Navigation properties
    public College? College { get; set; }
    public ICollection<CourseOffering> LectureOfferings { get; set; } = new List<CourseOffering>();
    public ICollection<ClassGroup> ClassGroups { get; set; } = new List<ClassGroup>();
    public ICollection<Exam> Exams { get; set; } = new List<Exam>();
}

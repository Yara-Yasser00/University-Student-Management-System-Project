using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 1 (Organisation & Lookups)
// Table: Room — see "USMS - Database Design Documentation", section 5.
public class Room
{
    // Primary key
    public string RoomCode { get; set; } = null!;

    // Foreign keys
    public string? CollegeCode { get; set; }

    // Columns
    public string Building { get; set; } = null!;
    public RoomType Type { get; set; }
    public short Capacity { get; set; }

    // Navigation properties
    public College? College { get; set; }
    public ICollection<CourseOffering> LectureOfferings { get; set; } = new List<CourseOffering>();
    public ICollection<ClassGroup> ClassGroups { get; set; } = new List<ClassGroup>();
    public ICollection<Exam> Exams { get; set; } = new List<Exam>();
}

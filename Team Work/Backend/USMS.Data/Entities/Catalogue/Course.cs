using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 3 (Catalogue & Schedule)
// Table: Course — see "USMS - Database Design Documentation", section 5.
public class Course
{
    // Primary key
    public int CourseID { get; set; }

    // Foreign keys
    public string CollegeCode { get; set; } = null!;

    // Columns
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public AcademicLevel Level { get; set; }
    public byte CreditHours { get; set; }
    public ActivityType ActivityType { get; set; }
    public EntityStatus Status { get; set; }

    // Navigation properties
    public College College { get; set; } = null!;
    public ICollection<DepartmentCourse> DepartmentCourses { get; set; } = new List<DepartmentCourse>();
    public ICollection<CoursePrerequisite> Prerequisites { get; set; } = new List<CoursePrerequisite>();
    public ICollection<CoursePrerequisite> RequiredFor { get; set; } = new List<CoursePrerequisite>();
    public ICollection<CourseOffering> Offerings { get; set; } = new List<CourseOffering>();
}

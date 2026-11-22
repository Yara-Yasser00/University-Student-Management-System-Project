namespace USMS.Data.Entities;

// Owner: Group 3 (Catalogue & Schedule)
// Table: CoursePrerequisite — see "USMS - Database Design Documentation", section 5.
public class CoursePrerequisite
{
    // Primary key
    public int CourseID { get; set; }
    public int PrerequisiteCourseID { get; set; }

    // Navigation properties
    public Course Course { get; set; } = null!;
    public Course PrerequisiteCourse { get; set; } = null!;
}

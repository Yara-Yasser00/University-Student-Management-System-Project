namespace USMS.Data.Entities;

// Owner: Group 3 (Catalogue & Schedule)
// Table: Course — see "USMS - Database Design Documentation", section 5.
public class Course
{
    // Primary key
    public int CourseID { get; set; }

    // Foreign keys
    public int DepartmentID { get; set; }

    // TODO Group 3 (Catalogue & Schedule): add the remaining columns from the ERD.

    // Navigation properties
    public Department Department { get; set; } = null!;
    public ICollection<CoursePrerequisite> Prerequisites { get; set; } = new List<CoursePrerequisite>();
    public ICollection<CoursePrerequisite> RequiredFor { get; set; } = new List<CoursePrerequisite>();
    public ICollection<CourseOffering> Offerings { get; set; } = new List<CourseOffering>();
}

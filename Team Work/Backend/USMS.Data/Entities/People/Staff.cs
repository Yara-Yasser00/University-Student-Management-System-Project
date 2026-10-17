namespace USMS.Data.Entities;

// Owner: Group 2 (People)
// Table: Staff — see "USMS - Database Design Documentation", section 5.
public class Staff : Person
{
    // Primary key is inherited from Person (PersonID).
    // In the database it is stored as column "StaffID".

    // Foreign keys
    public int DepartmentID { get; set; }

    // TODO Group 2 (People): add the remaining columns from the ERD.

    // Navigation properties
    public Department Department { get; set; } = null!;
    public College? DeanOfCollege { get; set; }
    public Department? HeadOfDepartment { get; set; }
    public ICollection<Student> AdvisedStudents { get; set; } = new List<Student>();
    public ICollection<CourseOffering> TaughtOfferings { get; set; } = new List<CourseOffering>();
    public ICollection<ClassGroup> AssistedGroups { get; set; } = new List<ClassGroup>();
    public ICollection<RegistrationForm> ReviewedRegistrationForms { get; set; } = new List<RegistrationForm>();
    public ICollection<Attendance> RecordedAttendances { get; set; } = new List<Attendance>();
    public ICollection<Exam> HeadedExams { get; set; } = new List<Exam>();
}

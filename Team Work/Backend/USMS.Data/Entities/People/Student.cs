using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 2 (People)
// Table: Student — see "USMS - Database Design Documentation", section 5,
// and the General Division change in the rules doc, section 9.1.
public class Student : Person
{
    // Primary key is inherited from Person (PersonID).
    // In the database it is stored as column "StudentID".

    // Foreign keys
    public string CollegeCode { get; set; } = null!;
    public int? DepartmentID { get; set; }              // NULL in years 1–2 (General Division)
    public int? AdvisorStaffID { get; set; }            // NULL if graduated or inactive

    // Columns
    public AcademicLevel Level { get; set; }
    public DateOnly EnrollmentDate { get; set; }
    public AcademicStatus AcademicStatus { get; set; }
    public string GuardianName { get; set; } = null!;
    public string? GuardianOccupation { get; set; }
    public string GuardianMobile { get; set; } = null!;
    public string City { get; set; } = null!;
    public string? HomePhone { get; set; }
    public string CertificateType { get; set; } = null!;
    public string SchoolName { get; set; } = null!;
    public short GraduationYear { get; set; }
    public decimal PreviousScore { get; set; }

    // Navigation properties
    public College College { get; set; } = null!;
    public Department? Department { get; set; }
    public Staff? AdvisorStaff { get; set; }
    public ICollection<RegistrationForm> RegistrationForms { get; set; } = new List<RegistrationForm>();
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

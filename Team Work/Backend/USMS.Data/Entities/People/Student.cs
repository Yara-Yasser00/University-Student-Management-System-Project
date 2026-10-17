namespace USMS.Data.Entities;

// Owner: Group 2 (People)
// Table: Student — see "USMS - Database Design Documentation", section 5.
public class Student : Person
{
    // Primary key is inherited from Person (PersonID).
    // In the database it is stored as column "StudentID".

    // Foreign keys
    public int DepartmentID { get; set; }
    public int? AdvisorStaffID { get; set; }

    // TODO Group 2 (People): add the remaining columns from the ERD.

    // Navigation properties
    public Department Department { get; set; } = null!;
    public Staff? AdvisorStaff { get; set; }
    public ICollection<RegistrationForm> RegistrationForms { get; set; } = new List<RegistrationForm>();
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

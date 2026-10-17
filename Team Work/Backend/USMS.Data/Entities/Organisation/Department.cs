namespace USMS.Data.Entities;

// Owner: Group 1 (Organisation & Lookups)
// Table: Department — see "USMS - Database Design Documentation", section 5.
public class Department
{
    // Primary key
    public int DepartmentID { get; set; }

    // Foreign keys
    public string CollegeCode { get; set; } = null!;
    public int? HeadStaffID { get; set; }

    // TODO Group 1 (Organisation & Lookups): add the remaining columns from the ERD.

    // Navigation properties
    public College College { get; set; } = null!;
    public Staff? HeadStaff { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Staff> StaffMembers { get; set; } = new List<Staff>();
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}

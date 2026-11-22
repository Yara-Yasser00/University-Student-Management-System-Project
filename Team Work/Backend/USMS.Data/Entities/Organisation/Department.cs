using USMS.Data.Enums;

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

    // Columns
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public EntityStatus Status { get; set; }

    // Navigation properties
    public College College { get; set; } = null!;
    public Staff? HeadStaff { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Staff> StaffMembers { get; set; } = new List<Staff>();
    public ICollection<DepartmentCourse> DepartmentCourses { get; set; } = new List<DepartmentCourse>();
}

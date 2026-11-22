using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 1 (Organisation & Lookups)
// Table: College — see "USMS - Database Design Documentation", section 5.
public class College
{
    // Primary key
    public string CollegeCode { get; set; } = null!;

    // Foreign keys
    public int? DeanStaffID { get; set; }

    // Columns
    public string NameEn { get; set; } = null!;
    public string NameAr { get; set; } = null!;
    public short EstablishedYear { get; set; }
    public string? LogoUrl { get; set; }
    public string? PhotoUrl { get; set; }
    public EntityStatus Status { get; set; }

    // Academic rules of the college (minimum earned credit hours for each level).
    public byte SophomoreCredits { get; set; }
    public byte JuniorCredits { get; set; }
    public byte SeniorCredits { get; set; }
    public byte GraduationCredits { get; set; }

    // Attendance rules (percentages, used for the warning and for exam deprivation).
    public byte AttendanceWarningPct { get; set; }
    public byte ExamDeprivationPct { get; set; }

    // Navigation properties
    public Staff? DeanStaff { get; set; }
    public ICollection<CreditLoadRule> CreditLoadRules { get; set; } = new List<CreditLoadRule>();
    public ICollection<Department> Departments { get; set; } = new List<Department>();
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
    public ICollection<CollegeAdmin> CollegeAdmins { get; set; } = new List<CollegeAdmin>();
    public ICollection<SchedulePublication> SchedulePublications { get; set; } = new List<SchedulePublication>();
    public ICollection<RegistrationPeriod> RegistrationPeriods { get; set; } = new List<RegistrationPeriod>();
    public ICollection<ExamPublication> ExamPublications { get; set; } = new List<ExamPublication>();
}

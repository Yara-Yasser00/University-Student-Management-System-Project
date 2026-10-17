namespace USMS.Data.Entities;

// Owner: Group 1 (Organisation & Lookups)
// Table: College — see "USMS - Database Design Documentation", section 5.
public class College
{
    // Primary key
    public string CollegeCode { get; set; } = null!;

    // Foreign keys
    public int? DeanStaffID { get; set; }

    // TODO Group 1 (Organisation & Lookups): add the remaining columns from the ERD.

    // Navigation properties
    public Staff? DeanStaff { get; set; }
    public ICollection<CreditLoadRule> CreditLoadRules { get; set; } = new List<CreditLoadRule>();
    public ICollection<Department> Departments { get; set; } = new List<Department>();
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
    public ICollection<CollegeAdmin> CollegeAdmins { get; set; } = new List<CollegeAdmin>();
    public ICollection<SchedulePublication> SchedulePublications { get; set; } = new List<SchedulePublication>();
    public ICollection<RegistrationPeriod> RegistrationPeriods { get; set; } = new List<RegistrationPeriod>();
    public ICollection<ExamPublication> ExamPublications { get; set; } = new List<ExamPublication>();
}

using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 3 (Catalogue & Schedule)
// Table: AcademicTerm — see "USMS - Database Design Documentation", section 5.
public class AcademicTerm
{
    // Primary key
    public int TermID { get; set; }

    // Columns
    public string AcademicYear { get; set; } = null!;
    public TermName TermName { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsCurrent { get; set; }

    // Navigation properties
    public ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();
    public ICollection<SchedulePublication> SchedulePublications { get; set; } = new List<SchedulePublication>();
    public ICollection<RegistrationPeriod> RegistrationPeriods { get; set; } = new List<RegistrationPeriod>();
    public ICollection<RegistrationForm> RegistrationForms { get; set; } = new List<RegistrationForm>();
    public ICollection<ExamPublication> ExamPublications { get; set; } = new List<ExamPublication>();
}

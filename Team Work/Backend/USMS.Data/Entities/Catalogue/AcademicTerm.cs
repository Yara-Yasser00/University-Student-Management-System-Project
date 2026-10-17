namespace USMS.Data.Entities;

// Owner: Group 3 (Catalogue & Schedule)
// Table: AcademicTerm — see "USMS - Database Design Documentation", section 5.
public class AcademicTerm
{
    // Primary key
    public int TermID { get; set; }

    // TODO Group 3 (Catalogue & Schedule): add the remaining columns from the ERD.

    // Navigation properties
    public ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();
    public ICollection<SchedulePublication> SchedulePublications { get; set; } = new List<SchedulePublication>();
    public ICollection<RegistrationPeriod> RegistrationPeriods { get; set; } = new List<RegistrationPeriod>();
    public ICollection<RegistrationForm> RegistrationForms { get; set; } = new List<RegistrationForm>();
    public ICollection<ExamPublication> ExamPublications { get; set; } = new List<ExamPublication>();
}

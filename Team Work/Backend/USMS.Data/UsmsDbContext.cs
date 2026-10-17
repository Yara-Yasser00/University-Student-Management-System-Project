using Microsoft.EntityFrameworkCore;
using USMS.Data.Entities;

namespace USMS.Data;

// Shared file: nobody needs to edit it while working on their group.
// Every table is configured in its own file under Configurations/.
public class UsmsDbContext : DbContext
{
    public UsmsDbContext(DbContextOptions<UsmsDbContext> options) : base(options) { }

    // Group 1: Organisation & Lookups
    public DbSet<College> Colleges => Set<College>();
    public DbSet<CreditLoadRule> CreditLoadRules => Set<CreditLoadRule>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<GradeScale> GradeScales => Set<GradeScale>();
    public DbSet<Permission> Permissions => Set<Permission>();

    // Group 2: People
    public DbSet<Person> People => Set<Person>();
    public DbSet<UserAccount> UserAccounts => Set<UserAccount>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Staff> StaffMembers => Set<Staff>();
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<UniversityAdmin> UniversityAdmins => Set<UniversityAdmin>();
    public DbSet<CollegeAdmin> CollegeAdmins => Set<CollegeAdmin>();

    // Group 3: Catalogue & Schedule
    public DbSet<AcademicTerm> AcademicTerms => Set<AcademicTerm>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CoursePrerequisite> CoursePrerequisites => Set<CoursePrerequisite>();
    public DbSet<CourseOffering> CourseOfferings => Set<CourseOffering>();
    public DbSet<ClassGroup> ClassGroups => Set<ClassGroup>();
    public DbSet<SchedulePublication> SchedulePublications => Set<SchedulePublication>();

    // Group 4: Registration
    public DbSet<RegistrationPeriod> RegistrationPeriods => Set<RegistrationPeriod>();
    public DbSet<RegistrationForm> RegistrationForms => Set<RegistrationForm>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Notification> Notifications => Set<Notification>();

    // Group 5: Teaching & Exams
    public DbSet<ClassSession> ClassSessions => Set<ClassSession>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<Exam> Exams => Set<Exam>();
    public DbSet<ExamSeat> ExamSeats => Set<ExamSeat>();
    public DbSet<ExamPublication> ExamPublications => Set<ExamPublication>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Picks up every IEntityTypeConfiguration<T> class in this project.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsmsDbContext).Assembly);
    }
}

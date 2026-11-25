using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USMS.Data.Entities;
using USMS.Data.Enums;

namespace USMS.Data.Configurations;

// Owner: Group 1 (Organisation & Lookups)
public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permission");
        builder.HasKey(e => e.PermissionKey);
        builder.Property(e => e.PermissionKey).HasMaxLength(60);

        // Columns
        builder.Property(e => e.Role).HasConversion<string>().HasMaxLength(20);     // UserRole
        builder.Property(e => e.GroupName).HasMaxLength(30);
        builder.Property(e => e.Label).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(300);

        // Relationships (from the ERD). Records are never deleted (status changes only),
        // so every foreign key uses Restrict. This also avoids multiple cascade paths.
        // R37: Permission.UpdatedByAdminID → UniversityAdmin
        builder.HasOne(e => e.UpdatedByAdmin)
               .WithMany(p => p.UpdatedPermissions)
               .HasForeignKey(e => e.UpdatedByAdminID)
               .OnDelete(DeleteBehavior.Restrict);

        // Seed data (fixed lookup values, agreed by the team)
        // The 30 permissions of the UI-UX prototype (permissions.ts). IsEnabled starts equal to DefaultOn.
        // student.dropCourses was removed on 25 November 2026 (Add / Drop removed).
        // The "requires" link between permissions has no column in the ERD; the API / UI handles it.
        builder.HasData(
            new Permission
            {
                PermissionKey = "student.viewProfile",
                Role = UserRole.Student,
                GroupName = "Profile",
                Label = "View profile",
                Description = "See personal and academic information on file.",
                DefaultOn = true,
                IsLocked = true,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "student.editContact",
                Role = UserRole.Student,
                GroupName = "Profile",
                Label = "Edit contact details",
                Description = "Change mobile number, address and emergency contact.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "student.registerCourses",
                Role = UserRole.Student,
                GroupName = "Registration",
                Label = "Register courses",
                Description = "Add and remove courses while the registration period is open.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "student.printRegistration",
                Role = UserRole.Student,
                GroupName = "Registration",
                Label = "Print registration form",
                Description = "Print or download the official registration form.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "student.viewSchedule",
                Role = UserRole.Student,
                GroupName = "Academic records",
                Label = "View schedule",
                Description = "See the weekly timetable of registered courses.",
                DefaultOn = true,
                IsLocked = true,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "student.viewAttendance",
                Role = UserRole.Student,
                GroupName = "Academic records",
                Label = "View attendance",
                Description = "See attendance percentage and lecture details.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "student.viewGrades",
                Role = UserRole.Student,
                GroupName = "Academic records",
                Label = "View published grades",
                Description = "See course results after the college publishes them.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "student.viewExams",
                Role = UserRole.Student,
                GroupName = "Academic records",
                Label = "View exam schedule",
                Description = "See midterm and final exam dates, rooms and seat numbers.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "student.downloadTranscript",
                Role = UserRole.Student,
                GroupName = "Academic records",
                Label = "Download transcript",
                Description = "Print or download the academic transcript.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "instructor.editContact",
                Role = UserRole.Instructor,
                GroupName = "Profile",
                Label = "Edit contact details",
                Description = "Change mobile number, office and emergency contact.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "instructor.recordAttendance",
                Role = UserRole.Instructor,
                GroupName = "Attendance",
                Label = "Record attendance",
                Description = "Mark students present, late or absent for current lectures, sections and labs.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "instructor.editCompletedAttendance",
                Role = UserRole.Instructor,
                GroupName = "Attendance",
                Label = "Edit attendance of completed lectures",
                Description = "Change attendance after a lecture has ended. Off by default to protect records.",
                DefaultOn = false,
                IsLocked = false,
                IsEnabled = false,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "instructor.enterGrades",
                Role = UserRole.Instructor,
                GroupName = "Grades",
                Label = "Enter grades",
                Description = "Fill grade components in the gradebook and save drafts.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "instructor.submitGrades",
                Role = UserRole.Instructor,
                GroupName = "Grades",
                Label = "Submit grades to college",
                Description = "Send a completed gradebook to the College Admin for approval.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "instructor.viewAdvisees",
                Role = UserRole.Instructor,
                GroupName = "Advising",
                Label = "View advisee records",
                Description = "Open academic records of students assigned for advising.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "instructor.exportRoster",
                Role = UserRole.Instructor,
                GroupName = "Courses",
                Label = "Export course roster",
                Description = "Download the list of students enrolled in a course.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.manageStudents",
                Role = UserRole.CollegeAdmin,
                GroupName = "People",
                Label = "Manage students",
                Description = "Add, edit, activate and deactivate student records.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.manageInstructors",
                Role = UserRole.CollegeAdmin,
                GroupName = "People",
                Label = "Manage instructors",
                Description = "Add, edit, activate and deactivate instructor records.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.assignAdvisors",
                Role = UserRole.CollegeAdmin,
                GroupName = "People",
                Label = "Assign academic advisors",
                Description = "Choose the academic advisor for each student.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.manageDepartments",
                Role = UserRole.CollegeAdmin,
                GroupName = "Structure",
                Label = "Manage departments",
                Description = "Add, edit and deactivate departments.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.manageCourses",
                Role = UserRole.CollegeAdmin,
                GroupName = "Structure",
                Label = "Manage courses",
                Description = "Edit the course catalogue, credits and prerequisites.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.editRules",
                Role = UserRole.CollegeAdmin,
                GroupName = "Structure",
                Label = "Edit academic rules",
                Description = "Change level progression, credit load and attendance thresholds.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.lectureSchedule",
                Role = UserRole.CollegeAdmin,
                GroupName = "Scheduling",
                Label = "Build and publish lecture schedule",
                Description = "Assign instructors, rooms and times, then publish to students.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.registrationPeriod",
                Role = UserRole.CollegeAdmin,
                GroupName = "Scheduling",
                Label = "Control registration period",
                Description = "Set registration dates.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.overrideRegistration",
                Role = UserRole.CollegeAdmin,
                GroupName = "Scheduling",
                Label = "Override registration manually",
                Description = "Close or reopen registration immediately, outside the saved dates.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.exams",
                Role = UserRole.CollegeAdmin,
                GroupName = "Scheduling",
                Label = "Schedule and publish exams",
                Description = "Create exam timetables, rooms, committees and seat numbers.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.approveResults",
                Role = UserRole.CollegeAdmin,
                GroupName = "Results",
                Label = "Approve results",
                Description = "Approve submitted course results or return them to the instructor.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.publishResults",
                Role = UserRole.CollegeAdmin,
                GroupName = "Results",
                Label = "Publish results",
                Description = "Make approved results visible to students.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.correctGrades",
                Role = UserRole.CollegeAdmin,
                GroupName = "Results",
                Label = "Correct grades (with reason)",
                Description = "Change a student grade after submission. Every correction is logged.",
                DefaultOn = true,
                IsLocked = false,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            },
            new Permission
            {
                PermissionKey = "college.viewStatistics",
                Role = UserRole.CollegeAdmin,
                GroupName = "Reports",
                Label = "View statistics",
                Description = "See success rates and enrollment statistics for the college.",
                DefaultOn = true,
                IsLocked = true,
                IsEnabled = true,
                UpdatedByAdminID = null,
                UpdatedAt = null
            });
    }
}

namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(20)) with .HasConversion<string>().
// Used by: UserAccount.Role, Permission.Role (Permission uses Student / Instructor / CollegeAdmin only)
public enum UserRole
{
    Student,
    Instructor,
    CollegeAdmin,
    UniversityAdmin
}

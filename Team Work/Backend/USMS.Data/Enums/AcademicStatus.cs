namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(15)) with .HasConversion<string>().
// Used by: Student.AcademicStatus
public enum AcademicStatus
{
    Continuing,
    Graduated,
    Suspended,
    Withdrawn
}

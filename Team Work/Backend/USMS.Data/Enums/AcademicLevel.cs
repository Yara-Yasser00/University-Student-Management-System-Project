namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(10)) with .HasConversion<string>().
// Used by: Student.Level, Course.Level, SchedulePublication.Level (part of the key)
public enum AcademicLevel
{
    Freshman,
    Sophomore,
    Junior,
    Senior
}

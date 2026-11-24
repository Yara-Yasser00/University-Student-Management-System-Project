namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(10)) with .HasConversion<string>().
// Used by: GradeCorrection.Component (the mark that was corrected)
public enum GradeComponent
{
    Attendance,
    Practical,
    Midterm,
    Oral,
    Final
}

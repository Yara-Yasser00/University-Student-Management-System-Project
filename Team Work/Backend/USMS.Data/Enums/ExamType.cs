namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(10)) with .HasConversion<string>().
// Used by: Exam.ExamType, ExamPublication.ExamType (part of the key)
public enum ExamType
{
    Midterm,
    Final
}

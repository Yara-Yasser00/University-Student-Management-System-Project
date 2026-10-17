namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(30)) with .HasConversion<string>().
// Used by: Staff.AcademicRank (values from the ERD Brief, section 7)
public enum AcademicRank
{
    Professor,
    AssociateProfessor,
    Lecturer,
    AssistantLecturer,
    TeachingAssistant
}

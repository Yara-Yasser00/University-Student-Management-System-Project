namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(3)) with .HasConversion<string>().
// Used by: CourseOffering.LectureDay, ClassGroup.Day
public enum WeekDay
{
    Sat,
    Sun,
    Mon,
    Tue,
    Wed,
    Thu
}

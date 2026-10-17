namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(20)) with .HasConversion<string>().
// Used by: Room.Type (the ERD writes "Lecture hall" / "Exam hall"; stored without the space)
public enum RoomType
{
    LectureHall,
    Classroom,
    Lab,
    ExamHall
}

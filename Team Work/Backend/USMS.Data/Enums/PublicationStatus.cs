namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(20)) with .HasConversion<string>().
// Used by: SchedulePublication.Status, ExamPublication.Status
public enum PublicationStatus
{
    Draft,
    Published,
    UnpublishedChanges
}

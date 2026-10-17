namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(10)) with .HasConversion<string>().
// Used by: CourseOffering.ResultStatus
public enum ResultStatus
{
    Draft,
    Submitted,
    Approved,
    Returned,
    Published
}

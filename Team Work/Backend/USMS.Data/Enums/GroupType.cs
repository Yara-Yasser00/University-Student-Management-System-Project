namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(10)) with .HasConversion<string>().
// Used by: ClassGroup.GroupType
public enum GroupType
{
    Section,
    Lab
}

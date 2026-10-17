namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(10)) with .HasConversion<string>().
// Used by: College.Status, Department.Status, UserAccount.Status, Staff.Status, Course.Status
public enum EntityStatus
{
    Active,
    Inactive
}

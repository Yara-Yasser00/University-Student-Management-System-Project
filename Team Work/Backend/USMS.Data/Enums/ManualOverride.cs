namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(15)) with .HasConversion<string>().
// Used by: RegistrationPeriod.ManualOverride
public enum ManualOverride
{
    None,
    ForcedClosed,
    ForcedOpen
}

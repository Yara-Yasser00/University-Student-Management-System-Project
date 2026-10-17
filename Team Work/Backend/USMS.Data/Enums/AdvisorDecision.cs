namespace USMS.Data.Enums;

// Shared enum — do not change without agreeing in the team group first.
// Stored as text (NVARCHAR(20)) with .HasConversion<string>().
// Used by: RegistrationForm.Decision
public enum AdvisorDecision
{
    AwaitingSignature,
    Approved,
    ChangesRequested
}

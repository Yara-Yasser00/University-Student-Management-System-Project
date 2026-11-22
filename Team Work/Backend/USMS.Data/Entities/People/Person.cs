namespace USMS.Data.Entities;

// Owner: Group 2 (People)
// Table: Person — see "USMS - Database Design Documentation", section 5.
// Superclass of Student, Staff and Admin (TPT): holds the personal data they share.
public abstract class Person
{
    // Primary key
    public int PersonID { get; set; }

    // Columns
    public string NameEn { get; set; } = null!;
    public string NameAr { get; set; } = null!;
    public string Gender { get; set; } = null!;          // values not listed in the ERD, so string
    public string Nationality { get; set; } = null!;
    public string NationalID { get; set; } = null!;     // unique
    public DateOnly DateOfBirth { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string Mobile { get; set; } = null!;         // editable by the user
    public string? Address { get; set; }
    public string? EmergencyName { get; set; }
    public string? EmergencyPhone { get; set; }

    // Navigation properties
    public UserAccount? UserAccount { get; set; }
}

namespace USMS.Data.Entities;

// Owner: Group 2 (People)
// Table: Person — see "USMS - Database Design Documentation", section 5.
public abstract class Person
{
    // Primary key
    public int PersonID { get; set; }

    // TODO Group 2 (People): add the remaining columns from the ERD.

    // Navigation properties
    public UserAccount? UserAccount { get; set; }
}

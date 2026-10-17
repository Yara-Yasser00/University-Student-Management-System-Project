namespace USMS.Data.Entities;

// Owner: Group 2 (People)
// Table: UniversityAdmin — see "USMS - Database Design Documentation", section 5.
public class UniversityAdmin : Admin
{
    // Primary key is inherited from Person (PersonID).
    // In the database it is stored as column "AdminID".

    // TODO Group 2 (People): add the remaining columns from the ERD.

    // Navigation properties
    public ICollection<Permission> UpdatedPermissions { get; set; } = new List<Permission>();
}

namespace USMS.Data.Entities;

// Owner: Group 2 (People)
// Table: UniversityAdmin — see "USMS - Database Design Documentation", section 5.
// The ERD gives this table only its key (AdminID); everything else is in Person and Admin.
public class UniversityAdmin : Admin
{
    // Primary key is inherited from Person (PersonID).
    // In the database it is stored as column "AdminID".

    // Navigation properties
    public ICollection<Permission> UpdatedPermissions { get; set; } = new List<Permission>();
}

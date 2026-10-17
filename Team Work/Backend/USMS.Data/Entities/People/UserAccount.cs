namespace USMS.Data.Entities;

// Owner: Group 2 (People)
// Table: UserAccount — see "USMS - Database Design Documentation", section 5.
public class UserAccount
{
    // Primary key
    public string LoginID { get; set; } = null!;

    // Foreign keys
    public int PersonID { get; set; }

    // TODO Group 2 (People): add the remaining columns from the ERD.

    // Navigation properties
    public Person Person { get; set; } = null!;
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}

namespace USMS.Data.Entities;

// Owner: Group 4 (Registration)
// Table: Notification — see "USMS - Database Design Documentation", section 5.
public class Notification
{
    // Primary key
    public int NotificationID { get; set; }

    // Foreign keys
    public string LoginID { get; set; } = null!;

    // TODO Group 4 (Registration): add the remaining columns from the ERD.

    // Navigation properties
    public UserAccount UserAccount { get; set; } = null!;
}

namespace USMS.Data.Entities;

// Owner: Group 4 (Registration)
// Table: Notification — see "USMS - Database Design Documentation", section 5.
public class Notification
{
    // Primary key
    public int NotificationID { get; set; }

    // Foreign keys
    public string LoginID { get; set; } = null!;

    // Columns
    public string Title { get; set; } = null!;
    public string Body { get; set; } = null!;
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public UserAccount UserAccount { get; set; } = null!;
}

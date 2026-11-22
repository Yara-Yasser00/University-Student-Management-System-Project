using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 2 (People)
// Table: UserAccount — see "USMS - Database Design Documentation", section 5.
// Sign-in credentials, kept apart from the personal data in Person.
public class UserAccount
{
    // Primary key
    public string LoginID { get; set; } = null!;        // ST-… / INS-… / ADM-…

    // Foreign keys
    public int PersonID { get; set; }                   // unique (1 : 1 with Person)

    // Columns
    public string Email { get; set; } = null!;          // unique, first.last@hurghada.edu
    public string PasswordHash { get; set; } = null!;
    public UserRole Role { get; set; }
    public EntityStatus Status { get; set; }
    public DateTime? LastSignInAt { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public Person Person { get; set; } = null!;
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}

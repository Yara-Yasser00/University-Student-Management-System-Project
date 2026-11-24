namespace USMS.Data.Entities;

// Owner: Group 1 (Organisation & Lookups)
// Table: PermissionChangeLog — added 24 November 2026 (see the rules doc, section 9.2).
// One row each time a University Admin switches a permission on or off
// ("Reset to defaults" adds one row for every permission it changes).
public class PermissionChangeLog
{
    // Primary key
    public int ChangeID { get; set; }

    // Foreign keys
    public string PermissionKey { get; set; } = null!;
    public int ChangedByAdminID { get; set; }

    // Columns
    public bool OldIsEnabled { get; set; }
    public bool NewIsEnabled { get; set; }
    public DateTime ChangedAt { get; set; }

    // Navigation properties
    public Permission Permission { get; set; } = null!;
    public UniversityAdmin ChangedByAdmin { get; set; } = null!;
}

namespace USMS.Data.Entities;

// Owner: Group 1 (Organisation & Lookups)
// Table: Permission — see "USMS - Database Design Documentation", section 5.
public class Permission
{
    // Primary key
    public string PermissionKey { get; set; } = null!;

    // Foreign keys
    public int? UpdatedByAdminID { get; set; }

    // TODO Group 1 (Organisation & Lookups): add the remaining columns from the ERD.

    // Navigation properties
    public UniversityAdmin? UpdatedByAdmin { get; set; }
}

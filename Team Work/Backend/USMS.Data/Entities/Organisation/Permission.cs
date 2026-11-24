using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 1 (Organisation & Lookups)
// Table: Permission — see "USMS - Database Design Documentation", section 5.
public class Permission
{
    // Primary key
    public string PermissionKey { get; set; } = null!;

    // Foreign keys
    public int? UpdatedByAdminID { get; set; }

    // Columns
    public UserRole Role { get; set; }
    public string GroupName { get; set; } = null!;
    public string Label { get; set; } = null!;
    public string? Description { get; set; }
    public bool DefaultOn { get; set; }
    public bool IsLocked { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public UniversityAdmin? UpdatedByAdmin { get; set; }
    public ICollection<PermissionChangeLog> ChangeLogs { get; set; } = new List<PermissionChangeLog>();
}

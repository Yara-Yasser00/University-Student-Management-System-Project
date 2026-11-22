using USMS.Data.Enums;

namespace USMS.Data.Entities;

// Owner: Group 2 (People)
// Table: Admin — see "USMS - Database Design Documentation", section 5.
// Superclass of UniversityAdmin and CollegeAdmin (TPT).
public abstract class Admin : Person
{
    // Primary key is inherited from Person (PersonID).
    // In the database it is stored as column "AdminID".

    // Columns
    public AdminType AdminType { get; set; }
}

namespace USMS.Data.Entities;

// Owner: Group 2 (People)
// Table: CollegeAdmin — see "USMS - Database Design Documentation", section 5.
public class CollegeAdmin : Admin
{
    // Primary key is inherited from Person (PersonID).
    // In the database it is stored as column "AdminID".

    // Foreign keys
    public string CollegeCode { get; set; } = null!;

    // TODO Group 2 (People): add the remaining columns from the ERD.

    // Navigation properties
    public College College { get; set; } = null!;
    public ICollection<CourseOffering> ApprovedOfferings { get; set; } = new List<CourseOffering>();
    public ICollection<CourseOffering> PublishedOfferings { get; set; } = new List<CourseOffering>();
}

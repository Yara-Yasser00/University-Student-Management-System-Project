namespace USMS.Data.Entities;

// Owner: Group 3 (Catalogue & Schedule)
// Table: DepartmentCourse — from the M:N relationship R13 "Course offered to Department".
// A row means: this course is offered to the students of this department.
// A course with no rows is a general course for the whole college (years 1–2).
// A course with several rows is shared between departments (e.g. Software for CS and IS).
public class DepartmentCourse
{
    // Primary key
    public int DepartmentID { get; set; }
    public int CourseID { get; set; }

    // Navigation properties
    public Department Department { get; set; } = null!;
    public Course Course { get; set; } = null!;
}

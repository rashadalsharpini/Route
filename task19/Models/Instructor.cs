using System.ComponentModel.DataAnnotations.Schema;

namespace EF03.Models;

public class Instructor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public decimal Bonus { get; set; }
    public string? address { get; set; }
    public decimal HourRate { get; set; }
    
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    
    public ICollection<CourseInstructor> CourseInstructors { get; set; }
}
using Microsoft.EntityFrameworkCore;

namespace EF03.Models;

[PrimaryKey(nameof(InstructorId), nameof(CourseId))]
public class CourseInstructor
{
    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public int Evaluate { get; set; }
}
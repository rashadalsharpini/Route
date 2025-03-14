using Microsoft.EntityFrameworkCore;

namespace EF03.Models;

[PrimaryKey(nameof(StudentId), nameof(CourseId))]
public class StudentCourse
{
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public int grade { get; set; }
}
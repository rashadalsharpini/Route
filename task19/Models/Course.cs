namespace EF03.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string duration { get; set; }
    public string? description { get; set; }
    
    
    public int TopicId { get; set; }
    public Topic Topic { get; set; }
    
    public ICollection<StudentCourse> StudentCourses { get; set; }
    
    public ICollection<CourseInstructor> CourseInstructors { get; set; }
}
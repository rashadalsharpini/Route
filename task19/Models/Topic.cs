namespace EF03.Models;

public class Topic
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Course> Courses { get; set; }
}
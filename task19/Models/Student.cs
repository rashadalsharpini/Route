namespace EF03.Models;

public class Student
{
    public int Id { get; set; }
    public string fName { get; set; }
    public string lName { get; set; }
    public string Address { get; set; }
    public int age { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    
    public ICollection<StudentCourse> StudentCourses { get; set; }


    public override string ToString()
    {
        return $"{Id} {fName} {lName} {Address} {age} {DepartmentId}";
    }
}
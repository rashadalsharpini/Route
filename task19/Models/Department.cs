using System.ComponentModel.DataAnnotations;

namespace EF03.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }

    [DataType(DataType.Date)]
    public DateTime HireDate { get; set; }


    public ICollection<Student> Students { get; set; }

    public ICollection<Instructor> Instructors { get; set; }

    public int? ManagerId { get; set; }
    public Instructor? Manager { get; set; }
}
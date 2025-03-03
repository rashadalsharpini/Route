using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2.models;

public class stud_course
{
    [Key]
    public int stud_id { get; set; }
    // [Key]
    public int course_id { get; set; }
    public int grade { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2.models;

public class course_inst
{
    [Key]
    public int inst_id { get; set; }
    // [Key]
    public int course_id { get; set; }
    public int evaluate { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.models;

public class course_inst
{
    [Key]
    public int inst_id { get; set; }
    public int course_id { get; set; }
    public int evaluate { get; set; }

}
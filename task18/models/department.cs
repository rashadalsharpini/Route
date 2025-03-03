using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp2.models;

public class department
{
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "VARCHAR(50)")]
    public string Name { get; set; }
    public int inst_id { get; set; }
    [DataType(DataType.Date)]
    public DateTime HiringDate {get;set;}
}
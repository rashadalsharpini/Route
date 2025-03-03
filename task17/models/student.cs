using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2.models;

public class student
{
    public int id { get; set; }
    public string fname { get; set; }
    public string lname { get; set; }
    public string address { get; set; }
    public int age { get; set; }
    public int department_id { get; set; }
}
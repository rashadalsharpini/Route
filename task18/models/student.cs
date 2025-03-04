namespace ConsoleApp1.models;

public class student
{
    public int id { get; set; }
    public string fname { get; set; }
    public string lname { get; set; }
    public string address { get; set; }
    public int age { get; set; }
    public int department_id { get; set; }
    public override string ToString()
    {
        return $"{fname} {lname} {address} {age} {department_id} {id}";
    }
}
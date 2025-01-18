namespace ConsoleApp2;

public class Employee
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public double Salary { get; private set; }
    public char Gender { get; private set; }
    public SecurityLevel SecurityLevel { get; private set; }
    public HiringDate HiringDate { get; private set; }

    public Employee(int id, string name, double salary, char gender, SecurityLevel securityLevel, HiringDate hiringDate)
    {
        if (gender != 'm' && gender != 'f')
            throw new ArgumentException("Invalid gender");
        ID = id;
        Name = name;
        Salary = salary;
        Gender = gender;
        SecurityLevel = securityLevel;
        HiringDate = hiringDate;    
    }

    public override string ToString()
    {
        return $"Name: {Name}, ID: {ID}, Salary: {Salary}, Gender: {Gender}, SecurityLevel: {SecurityLevel}, HiringDate: {{{HiringDate}}}";
    }
    
}
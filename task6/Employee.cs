namespace ConsoleApp1;

public class Employee : IComparable<Employee>
{
    // Properties
    public int ID { get; private set; }
    public string Name { get; private set; }
    public SecurityPrivilege SecurityLevel { get; private set; }
    public decimal Salary { get; private set; }
    public HiringDate HireDate { get; private set; }
    public char Gender { get; private set; }

    // Constructor
    public Employee(int id, string name, SecurityPrivilege securityLevel, decimal salary, HiringDate hireDate, char gender)
    {
        if (gender != 'M' && gender != 'F')
            throw new ArgumentException("Gender must be 'M' or 'F'.");

        ID = id;
        Name = name;
        SecurityLevel = securityLevel;
        Salary = salary;
        HireDate = hireDate;
        Gender = gender;
    }

    // Override ToString() to represent employee data as a string
    public override string ToString()
    {
        string formattedSalary = String.Format("{0:C}", Salary); // Format salary as currency
        return $"ID: {ID}, Name: {Name}, Security Level: {SecurityLevel}, Salary: {formattedSalary}, Hire Date: {HireDate}, Gender: {Gender}";
    }

    // Implement IComparable for sorting
    public int CompareTo(Employee other)
    {
        if (other == null) return 1;
        return HireDate.CompareTo(other.HireDate);
    }
}

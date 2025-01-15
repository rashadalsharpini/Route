namespace ConsoleApp1;

// Employee class
public class Employee
{
    // Properties
    public int ID { get; set; }
    public string Name { get; set; }
    public SecurityPrivilege SecurityLevel { get; set; }
    public decimal Salary { get; set; }
    public HiringDate HireDate { get; set; } // Use HiringDate instead of DateTime
    private char _gender;

    // Gender property with validation
    public char Gender
    {
        get { return _gender; }
        set
        {
            if (value == 'M' || value == 'F')
            {
                _gender = value;
            }
            else
            {
                throw new ArgumentException("Gender must be 'M' or 'F'.");
            }
        }
    }

    // Constructor
    public Employee(int id, string name, SecurityPrivilege securityLevel, decimal salary, HiringDate hireDate, char gender)
    {
        ID = id;
        Name = name;
        SecurityLevel = securityLevel;
        Salary = salary;
        HireDate = hireDate;
        Gender = gender; // Validation happens in the setter
    }

    // Override ToString() to represent employee data as a string
    public override string ToString()
    {
        string formattedSalary = String.Format("{0:C}", Salary); // Format salary as currency
        return $"ID: {ID}, Name: {Name}, Security Level: {SecurityLevel}, Salary: {formattedSalary}, Hire Date: {HireDate}, Gender: {Gender}";
    }
}
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a valid hiring date
                HiringDate hiringDate = new HiringDate(15, 5, 2020);

                // Create an employee object
                Employee emp = new Employee(
                    id: 1,
                    name: "John Doe",
                    securityLevel: SecurityPrivilege.Developer,
                    salary: 75000.50m,
                    hireDate: hiringDate,
                    gender: 'M'
                );

                // Display employee details
                Console.WriteLine(emp.ToString());

                // Attempt to create an invalid hiring date
                HiringDate invalidHiringDate = new HiringDate(21, 2, 2020); // This will throw an exception
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
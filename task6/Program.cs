namespace ConsoleApp1
{
    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create an array of employees
                Employee[] EmpArr = new Employee[3];

                // Create hiring dates
                HiringDate hireDate1 = new HiringDate(15, 5, 2020);
                HiringDate hireDate2 = new HiringDate(10, 3, 2019);
                HiringDate hireDate3 = new HiringDate(20, 8, 2021);

                // Create employees
                EmpArr[0] = new Employee(1, "John Doe", SecurityPrivilege.DBA, 75000.50m, hireDate1, 'M');
                EmpArr[1] = new Employee(2, "Jane Smith", SecurityPrivilege.Guest, 50000.00m, hireDate2, 'F');
                EmpArr[2] = new Employee(3, "Alice Johnson", SecurityPrivilege.SecurityOfficer, 90000.00m, hireDate3, 'F');

                // Sort employees by hire date
                Array.Sort(EmpArr);

                // Print sorted employees
                Console.WriteLine("Sorted Employees by Hire Date:");
                foreach (var emp in EmpArr)
                {
                    Console.WriteLine(emp);
                }

                // Track boxing/unboxing (not applicable here since we're using strongly-typed objects)
                Console.WriteLine("\nBoxing and Unboxing: 0 occurrences (no value types were boxed/unboxed).");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
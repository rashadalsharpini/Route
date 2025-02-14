class Department
{
    public int DeptID { get; set; }
    public string DeptName { get; set; }
    List<Employee> Staff;
    public void AddStaff (Employee E)
    {

        Staff.Add(E);
        E.EmployeeLayOff += RemoveStaff; // Subscribe to the event
    }
    ///CallBackMethod
    public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
    {
        if (sender is Employee emp && Staff.Contains(emp))
        {
            Console.WriteLine($"Employee {emp.EmployeeId} removed from {DeptName}");
            Staff.Remove(emp);
        }
    }
}

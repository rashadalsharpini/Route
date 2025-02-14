class Club
{
    public int ClubID { get; set; }
    public String ClubName { get; set; }
    List<Employee> Members;
    public void AddMember(Employee E)
    {
        Members.Add(E);
        E.EmployeeLayOff += RemoveMember; // Subscribe to event
    }
    ///CallBackMethod
    public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
    {
        if (sender is Employee emp && e.Cause == LayOffCause.VacationStockExceeded)
        {
            Console.WriteLine($"Removing Employee {emp.EmployeeId} from {ClubName} due to {e.Cause}.");
            Members.Remove(emp);
        }
    }

}

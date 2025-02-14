class SalesPerson:Employee
{
    public int AchievedTarget { get; set; }
    public bool CheckTarget (int Quota)
    {
        if (AchievedTarget < Quota)
        {
            Console.WriteLine($"SalesPerson {EmployeeId} failed to meet sales target.");
            OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.TargetNotMet });
            return false;
        }
        return true;
    }
}
class BoardMember:Employee
{
    public void Resign()
    {
        Console.WriteLine($"Board Member {EmployeeId} has resigned.");
        OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.Resign });
    }

    protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
    {
        if (e.Cause == LayOffCause.Resign)
        {
            base.OnEmployeeLayOff(e);
        }
    }
}

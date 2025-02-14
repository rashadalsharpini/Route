class Employee
{
    public int EmployeeId { get; set; }
    public event EventHandler<EmployeeLayOffEventArgs>? EmployeeLayOff;
    
    protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
    {
        EmployeeLayOff?.Invoke(this, e);
    }
    private DateTime _birthday;
    public DateTime BirthDate
    {
        get => _birthday;
        set => _birthday = value;
    }

    public int VacationStock { get; set; }

    public bool RequestVacation (DateTime from , DateTime to)
    {
        int requestedDays = (int)(to - from).TotalDays;
        if (requestedDays > VacationStock)
        {
            Console.WriteLine($"Employee {EmployeeId} doesn't have enough vacation days.");
            OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.VacationStockExceeded });
            return false;
        }
        VacationStock -= requestedDays;
        return true;
    }
    public void EndOfYearOperation ()
    {
        int age = DateTime.Now.Year - BirthDate.Year;
        if (BirthDate > DateTime.Now.AddYears(-age)) age--; // Adjust age

        if (age > 60)
        {
            Console.WriteLine($"Employee {EmployeeId} is too old to continue.");
            OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.TooOld });
        }
    }
}

public enum LayOffCause
{
    VacationStockExceeded = 1,
    TooOld,
    TargetNotMet,
    Resign,
}

public class EmployeeLayOffEventArgs : EventArgs
{
    public LayOffCause Cause { get; set; }
}

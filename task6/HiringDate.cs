namespace ConsoleApp1;

public class HiringDate : IComparable<HiringDate>
{
    // Properties
    public int Day { get; private set; }
    public int Month { get; private set; }
    public int Year { get; private set; }

    // Constructor
    public HiringDate(int day, int month, int year)
    {
        if (!IsValidDate(day, month, year))
            throw new ArgumentException("Invalid date.");

        Day = day;
        Month = month;
        Year = year;
    }

    // Method to validate the date
    private bool IsValidDate(int day, int month, int year)
    {
        try
        {
            DateTime date = new DateTime(year, month, day);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public override string ToString()
    {
        return $"{Day:D2}/{Month:D2}/{Year}"; // Format as DD/MM/YYYY
    }

    // Implement IComparable for sorting
    public int CompareTo(HiringDate other)
    {
        if (other == null) return 1;

        int yearComparison = Year.CompareTo(other.Year);
        if (yearComparison != 0) return yearComparison;

        int monthComparison = Month.CompareTo(other.Month);
        if (monthComparison != 0) return monthComparison;

        return Day.CompareTo(other.Day);
    }
}
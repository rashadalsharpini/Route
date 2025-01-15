namespace ConsoleApp1;

// HiringDate class to represent the hiring date
public class HiringDate
{
    // Fields
    private int _day;
    private int _month;
    private int _year;

    // Properties with validation
    public int Day
    {
        get { return _day; }
        set
        {
            if (value < 1 || value > 31)
                throw new ArgumentException("Day must be between 1 and 31.");
            _day = value;
        }
    }

    public int Month
    {
        get { return _month; }
        set
        {
            if (value < 1 || value > 12)
                throw new ArgumentException("Month must be between 1 and 12.");
            _month = value;
        }
    }

    public int Year
    {
        get { return _year; }
        set
        {
            if (value < 1900 || value > DateTime.Now.Year)
                throw new ArgumentException($"Year must be between 1900 and {DateTime.Now.Year}.");
            _year = value;
        }
    }

    // Constructor
    public HiringDate(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;

        // Validate the date
        if (!IsValidDate(day, month, year))
            throw new ArgumentException("Invalid date.");
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

    // Override ToString() to represent the hiring date in a readable format
    public override string ToString()
    {
        return $"{Day:D2}/{Month:D2}/{Year}"; // Format as DD/MM/YYYY
    }
}

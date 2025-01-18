namespace ConsoleApp2;

public class HiringDate
{
    public int day { get; set; }
    public int month { get; set; }
    public int year { get; set; }

    public HiringDate(int day, int month, int year)
    {
        if (!IsValidDate(day, month, year))
            throw new ArgumentException("Invalid date");
        this.day = day;
        this.month = month;
        this.year = year;
    }

    private bool IsValidDate(int day, int month, int year)
    {
        if (year < 1 || year > 9999 || month < 1 || month > 12 || day < 1 || day > 31)
            return false;
        if (day > DateTime.DaysInMonth(year, month))
            return false;
        return true;
    }

    public override string ToString()
    {
        return $"Day: {day}, Month: {month}, Year: {year}";
    }
}
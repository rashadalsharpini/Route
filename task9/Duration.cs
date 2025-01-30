namespace ConsoleApp1;

public class Duration
{
    public Duration(int hours, int minutes, int seconds=0)
    {
        Seconds = seconds;
        Minutes = minutes;
        Hours = hours;
    }
    public Duration(int totalSeconds)
    {
        Hours = totalSeconds / 3600;
        int remainingSeconds = totalSeconds % 3600;
        Minutes = remainingSeconds / 60;
        Seconds = remainingSeconds % 60;
    }

    private static int convert(Duration d1)
    {
        return (d1.Hours * 3600) + (d1.Minutes * 60) + d1.Seconds;
    }
    Duration()
    {
        
    }

    public int Seconds { get; set; }
    public int Minutes { get; set; }
    public int Hours { get; set; }

    public override string ToString()
    {
        if (Hours > 0)
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        else if (Minutes > 0)
            return $"Minutes: {Minutes}, Seconds: {Seconds}";
        else
            return $"Seconds: {Seconds}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Duration other)
            return false;
        return this.Hours == other.Hours 
               && this.Minutes == other.Minutes 
               && this.Seconds == other.Seconds;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Seconds, Minutes, Hours);
    }

    public static Duration operator +(Duration d1, Duration d2)
    {
        return new Duration(convert(d1) + convert(d2));
    }
    public static Duration operator -(Duration d1, Duration d2)
    {
        return new Duration(convert(d2) - convert(d1));
    }
    public static Duration operator +(Duration d1, int seconds)
    {
        return new Duration(convert(d1)+seconds);
    }
    public static Duration operator +(int seconds, Duration d1)
    {
        return new Duration(convert(d1)+seconds);
    }
    public static Duration operator -(Duration d1, int seconds)
    {
        return new Duration(convert(d1)-seconds);
    }
    public static Duration operator -(int seconds, Duration d1)
    {
        return new Duration(convert(d1)-seconds);
    }

    public static Duration operator ++(Duration d1)
    {
        return d1 = new Duration(convert(d1) + 60);
    }
    public static Duration operator --(Duration d1)
    {
        return d1 = new Duration(convert(d1)-60);
    }

    public static bool operator >(Duration d1, Duration d2)
    {
        return convert(d1) > convert(d2);
    }

    public static bool operator <(Duration d1, Duration d2)
    {
        return convert(d1) < convert(d2);
    }

    public static bool operator <=(Duration d1, Duration d2)
    {
        return convert(d1) <= convert(d2);
    }
    public static bool operator >=(Duration d1, Duration d2)
    {
        return convert(d1) >= convert(d2);
    }
    public static bool operator true(Duration d1)
    {
        return convert(d1) != 0;
    }

    public static bool operator false(Duration d1)
    {
        return convert(d1) == 0;
    }

    public static explicit operator DateTime(Duration d1)
    {
        DateTime baseDateTime = DateTime.MinValue;
        return baseDateTime.AddSeconds(convert(d1));
    } 
}

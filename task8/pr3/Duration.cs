namespace ConsoleApp2;

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
    public int Seconds { get; }
    public int Minutes { get; }
    public int Hours { get; }

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
}
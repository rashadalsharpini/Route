namespace ConsoleApp1;

public class Range<T> where T : IComparable<T>
{
    private T _min;
    private T _max;

    public Range(T min, T max)
    {
        _min = min;
        _max = max;
    }

    public bool IsInRange(T value)
    {
        return value.CompareTo(_min) >= 0 && value.CompareTo(_max) <= 0;
    }
    // in the begging it was T but gave me an error so searhed
    // and dynamic from my understanding allows you to determine the data type 
    // in the running time
    public dynamic length()
    {
        return (dynamic)_max - (dynamic)_min;
    }
}
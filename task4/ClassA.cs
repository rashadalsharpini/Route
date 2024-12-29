namespace ConsoleApp1;

public enum weekday
{
    saturday,
    sunday,
    monday,
    tuesday,
    wednesday,
    thursday,
    friday
}
public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}

[Flags]
public enum Permissions : byte
{
    None = 0,
    Read = 1,
    Write = 2,
    Delete = 4,
    Execute = 8
}
public enum Colors
{
    Red,
    Green,
    Blue
}
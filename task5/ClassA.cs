namespace ConsoleApp1;

#region 1
public struct Person
{
    private int _age;
    public int Age
    {
        set { _age = (value > 5) ? value : 0; }
        get {return _age;} 
    }
    private string _name;
    public string Name
    {
        set { _name = value; }
        get {return _name;}
    }
}
#endregion

#region 2

public struct Point
{
    private int _x, _y;

    public int X
    {
        set { _x = value; }
        get { return _x; }
    }

    public int Y
    {
        set{_y = value; }
        get { return _y; }
    }

    public static double Distance(Point p1, Point p2)
    {
        int diffx = p2.X - p1.X;
        int diffy = p2.Y - p1.Y;
        return Math.Sqrt(diffx * diffx + diffy * diffy);
    }
}
#endregion

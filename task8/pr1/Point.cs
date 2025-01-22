namespace ConsoleApp2;

public class Point: ICloneable, IComparable<Point>
{
    public double x { get; set; }
    public double y { get; set; }
    public double z { get; set; }
    public Point(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Point():this(0,0,0){}
    public int CompareTo(Point? other)
    {
        if (other == null) return 1;
        int rx = this.x.CompareTo(other.x);
        if (rx != 0) return rx;
        return this.y.CompareTo(other.y);
    }

    public override string ToString()
    {
        return $"point coordinates({x}, {y}, {z})";
    }

    public object Clone()
    {
        return new Point(this.x, this.y, this.z);
    }

    public static bool operator ==(Point a, Point b)
    {
        if(ReferenceEquals(a, b)) return true;
        if(ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
        return a.x == b.x && a.y == b.y && a.z == b.z;
    }

    public static bool operator !=(Point a, Point b)
    {
        return !(a == b);
    }
}
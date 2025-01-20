ICircle circle = new Circle { Radius = 5 };
circle.DisplayShapeInfo();
IRectangle rectangle = new Rectangle { Width = 5, Height = 5 };
rectangle.DisplayShapeInfo();

public interface IShape
{
    double Area { get; }
    void DisplayShapeInfo();
}

public interface ICircle : IShape
{
    double Radius { set; get; }
}

public interface IRectangle : IShape
{
    double Width { set; get; }
    double Height { set; get; }
}

public class Circle : ICircle
{
    public double Radius { set; get; }
    public double Area => Math.PI * Radius * Radius;

    public void DisplayShapeInfo()
    {
        Console.WriteLine("Circle");
        Console.WriteLine($"Radius: {Radius}");
        Console.WriteLine($"Area: {Area}");
    }
}

public class Rectangle : IRectangle
{
    public double Width { set; get; }
    public double Height { set; get; }
    public double Area => Width * Height;

    public void DisplayShapeInfo()
    {
        Console.WriteLine("Rectangle");
        Console.WriteLine($"Width: {Width}");
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"Area: {Area}");
    }
}

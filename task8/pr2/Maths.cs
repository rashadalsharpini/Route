namespace ConsoleApp2;

public class Maths
{
    public static double Add(double a, double b) => a + b;
    public static double Sub(double a, double b) => a - b;
    public static double Multiply(double a, double b) => a * b;

    public static double Divide(double a, double b)
    {
        if(b == 0)
            throw new DivideByZeroException("can't Divide by zero");
        return a / b;
    }
}
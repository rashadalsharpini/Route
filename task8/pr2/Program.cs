using ConsoleApp2;

Console.WriteLine("Sum: "+Maths.Add(1, 2));
Console.WriteLine("Sub: "+Maths.Sub(1, 2));
Console.WriteLine("Multiply: "+Maths.Multiply(1, 2));
try
{
    Console.WriteLine("Division: "+Maths.Divide(1, 0));
}
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
    throw;
}
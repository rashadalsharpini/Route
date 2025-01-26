namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Duration d1 = new Duration(3660);
        Duration d2 = new Duration(3661);
        // Console.WriteLine(d1+d2);
        // Console.WriteLine(d1+1);
        // Console.WriteLine(1+d1);
        // Console.WriteLine(d1-1);
        // Console.WriteLine(1-d1);
        // Console.WriteLine(d1);
        // Console.WriteLine(++d1);
        // Console.WriteLine(--d1);
        Console.WriteLine(d1?1:0);
        DateTime dat = (DateTime)d1;
        Console.WriteLine(d1);
        Console.WriteLine(dat);
        /*
         * i don't understand the output
         * and i don't know what the output should be
         */
    }
}
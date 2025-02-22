using System.Diagnostics;

namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Subject subject = new Subject(1, "c#");
        subject.CreateExam();
        Console.Clear();
        
        
        Console.WriteLine("Do You Want To Start Your Exam [y,n]");
        if (Char.Parse(Console.ReadLine()) == 'y')
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            subject.PrintExam();
            Console.WriteLine("Time Taken: " + sw.Elapsed);
        }

    }
}
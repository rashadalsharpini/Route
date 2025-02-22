using System.Diagnostics;

namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Subject subject = new Subject(1, "c#");
        subject.createExam();
        Console.Clear();
        
        // FinalExam finalExam = new FinalExam();
        // finalExam.CreateExam(2,60);
        // finalExam.ShowExam(3);
        
        Console.WriteLine("Do You Want To Start Your Exam [y,n]");
        if (Char.Parse(Console.ReadLine()) == 'y')
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            subject.printExam();
            Console.WriteLine("Time Taken: " + sw.Elapsed);
        }

    }
}
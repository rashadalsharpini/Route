namespace ConsoleApp2;

public class Subject
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public Exam Exam { get; set; }

    public Subject(int id, string name)
    {
        SubjectId = id;
        SubjectName = name;
    }

    public void CreateExam()
    {
        Console.WriteLine("creating exam");
        Console.Write("final exam 1 - practical exam 2: ");
        int option = Convert.ToInt32(Console.ReadLine());
        Console.Write("enter time: ");
        int time = Convert.ToInt32(Console.ReadLine());
        Console.Write("enter number of questions: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (option == 1)
        {
            Exam = new FinalExam(time, number);
            Exam.CreateExam();
        }else if (option == 2)
        {
            Exam = new PracticalExam(time, number);
            Exam.CreateExam();
        }
    }

    public void PrintExam()
    {
        Exam.Showexam();
    }
}
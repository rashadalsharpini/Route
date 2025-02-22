namespace ConsoleApp2;

public class Subject
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public Exam Exam { get; set; }

    public Subject(int id, string name, Exam exam)
    {
        SubjectId = id;
        SubjectName = name;
        Exam = exam;
    }

    public void createExam()
    {
        Console.WriteLine("creating exam");
        Console.WriteLine("final exam 1 - practical exam 2");
        int option = Convert.ToInt32(Console.ReadLine());
        if (option == 1)
        {
            Console.WriteLine("enter time: ");
            int time = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter number of questions: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Exam = new FinalExam(time, number);
            Exam.CreateExam();
        }else if (option == 2)
        {Console.WriteLine("enter time: ");
            int time = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter number of questions: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Exam = new PracticalExam(time, number);
            Exam.CreateExam();
        }
    }
}
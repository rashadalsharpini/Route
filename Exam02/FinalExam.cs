namespace ConsoleApp2;

public class FinalExam : Exam
{
    public FinalExam(int time, int numQuestions) : base(time, numQuestions){}

    public override void showexam()
    {
        Console.WriteLine("Final Exam");
        foreach (var q in Questions)
        {
            q.display();
        }
    }
}
namespace ConsoleApp2;

public class PracticalExam : Exam
{
    public PracticalExam(int time, int numQuestions) : base(time, numQuestions){}

    public override void showexam()
    {
        Console.WriteLine("Practical Exam");
        foreach (var q in Questions)
        {
            q.display();
            Console.WriteLine($"Correct Answer:{q.CorrectAnswerId}");
        }
    }

    public override void CreateExam()
    {
        Console.WriteLine("Practical Exam");
        while (NumberOfQuestions!=0)
        {
            Questions.Add(MCQ.addquestion());
            NumberOfQuestions--;
        }
    }
}
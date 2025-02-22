namespace ConsoleApp2;

public class PracticalExam : Exam
{
    public PracticalExam(int time, int numQuestions) : base(time, numQuestions){}

    public override void Showexam()
    {
        int sum = 0, fullSum = 0;
        Console.WriteLine("Practical Exam");
        foreach (var q in Questions)
        {
            fullSum += q.Mark;
            q.Display();
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == q.CorrectAnswerId)
                sum += q.Mark;
            else
                Console.WriteLine("wrong answer"); 
        }
        Console.WriteLine($"your degree = {sum} / {fullSum}");

    }

    public override void CreateExam()
    {
        Console.WriteLine("Practical Exam");
        while (NumberOfQuestions!=0)
        {
            Questions.Add(Mcq.Addquestion());
            NumberOfQuestions--;
        }
    }
}
using System.Diagnostics;

namespace ConsoleApp2;

public class FinalExam : Exam
{
    public FinalExam(int time, int numQuestions) : base(time, numQuestions){}

    public override void Showexam()
    {
        int sum = 0, fullSum = 0;
        Console.WriteLine("Final Exam");
        foreach (var q in Questions)
        {
            q.Display();
            fullSum += q.Mark;
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
        Console.WriteLine("Final Exam");
        while (NumberOfQuestions!=0)
        {
            Console.Write("mcq1 / true-false2: ");
            int flag = Convert.ToInt32(Console.ReadLine());
            if (flag == 1)
            {
                Questions.Add(Mcq.Addquestion());
            }else if (flag == 2)
            {
                Questions.Add(TrueFalse.Addquestion());
            }
            NumberOfQuestions--;
        }
        
    }
}
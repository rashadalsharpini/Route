using System.Diagnostics;

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
            Console.WriteLine($"Correct Answer:{q.CorrectAnswerId}");
        }
    }

    public override void CreateExam()
    {
        Console.WriteLine("Final Exam");
        while (NumberOfQuestions!=0)
        {
            Console.WriteLine("mcq0 / true-false1");
            int flag = Convert.ToInt32(Console.ReadLine());
            if (flag == 0)
            {
                Questions.Add(MCQ.addquestion());
            }else if (flag == 1)
            {
                Questions.Add(TrueFalse.addquestion());
            }
            NumberOfQuestions--;
        }
        
    }
}
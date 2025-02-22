namespace ConsoleApp2;

public class MCQ : Question
{
    public MCQ(string header, string body, int mark, List<Answer> answer) : base(header, body, mark)
    {
        answers = answer;
    }

    public override void display()
    {
        Console.WriteLine($"{Header}, {Body}, {Mark}");
        foreach (var ans in answers)
        {
            Console.WriteLine(ans);
        }
    }
}
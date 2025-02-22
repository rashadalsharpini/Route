namespace ConsoleApp2;

public class TrueFalse : Question
{
    public TrueFalse(string header, string body, int mark):base(header, body, mark)
    {
        answers.Add(new Answer(1, "True"));
        answers.Add(new Answer(2, "False"));
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
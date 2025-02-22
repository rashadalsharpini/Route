namespace ConsoleApp2;

public class TrueFalse : Question
{
    public TrueFalse(string header, string body, int mark, int correctAnswerId):base(header, body, mark, correctAnswerId)
    {
        choices.Add(new Answer(1, "True"));
        choices.Add(new Answer(2, "False"));
    }

    public override void display()
    {
        Console.WriteLine($"{Header}, {Body}, {Mark}");
        foreach (var ans in choices)
        {
            Console.WriteLine(ans);
        }
        Console.WriteLine("1 for true - 0 for false");

    }

    public static TrueFalse addquestion()
    {
        Console.WriteLine("enter header");
        string header = Console.ReadLine();
        Console.WriteLine("enter body");
        string body = Console.ReadLine();
        Console.WriteLine("enter mark");
        int mark = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter correct answer id 0 for false and 1 for true: ");
        int ansid = Convert.ToInt32(Console.ReadLine());
        return new TrueFalse(header, body, mark, ansid);
    }
}
namespace ConsoleApp2;

public class TrueFalse : Question
{
    public TrueFalse(string? header, string? body, int mark, int correctAnswerId):base(header, body, mark, correctAnswerId)
    {
        Choices.Add(new Answer(1, "True"));
        Choices.Add(new Answer(2, "False"));
    }

    public override void Display()
    {
        Console.WriteLine($"{Header}: {Body}? Mark: {Mark}");
        foreach (var ans in Choices)
        {
            Console.WriteLine(ans);
        }
        Console.WriteLine("1 for true - 0 for false");

    }

    public static TrueFalse Addquestion()
    {
        Console.Write("enter header: ");
        string? header = Console.ReadLine();
        Console.Write("enter body: ");
        string? body = Console.ReadLine();
        Console.Write("enter mark: ");
        int mark = Convert.ToInt32(Console.ReadLine());
        Console.Write("enter correct answer id 0 for false and 1 for true: ");
        int ansid = Convert.ToInt32(Console.ReadLine());
        return new TrueFalse(header, body, mark, ansid);
    }
}
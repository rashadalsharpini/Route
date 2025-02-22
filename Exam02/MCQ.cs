namespace ConsoleApp2;

public class Mcq : Question
{
    public Mcq(string? header, string? body, int mark,int correctAnswerId, List<Answer> choice) : base(header, body, mark, correctAnswerId)
    {
        Choices = choice;
    }

    public override void Display()
    {
        Console.WriteLine($"{Header}: {Body}? Mark: {Mark}");
        foreach (var ans in Choices)
        {
            Console.WriteLine(ans);
        }
        Console.Write("enter 1-2-3 is a choice");
    }

    public static Mcq Addquestion()
    {
        Console.Write("enter header: ");
        string? header = Console.ReadLine();
        Console.Write("enter body: ");
        string? body = Console.ReadLine();
        Console.Write("enter mark: ");
        int mark = Convert.ToInt32(Console.ReadLine());
        List<Answer> ans = new List<Answer>();
        for (int i = 0; i < 3; i++)
        {
            Console.Write("enter choose: ");
            string? choose = Console.ReadLine();
            ans.Add(new Answer(i+1, choose));
        }
        Console.Write("enter correct answer id 1-2-3 is a choice: ");
        int ansid = Convert.ToInt32(Console.ReadLine());
        return new Mcq(header, body, mark, ansid, ans);
    }
}
namespace ConsoleApp2;

public class MCQ : Question
{
    public MCQ(string header, string body, int mark,int correctAnswerId, List<Answer> choice) : base(header, body, mark, correctAnswerId)
    {
        choices = choice;
    }

    public override void display()
    {
        Console.WriteLine($"{Header}, {Body}, {Mark}");
        foreach (var ans in choices)
        {
            Console.WriteLine(ans);
        }
        Console.WriteLine("enter 1-2-3 is a choice");
    }

    public static MCQ addquestion()
    {
        Console.WriteLine("enter header");
        string header = Console.ReadLine();
        Console.WriteLine("enter body");
        string body = Console.ReadLine();
        Console.WriteLine("enter mark");
        int mark = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter choices");
        List<Answer> ans = new List<Answer>();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("enter choose: ");
            string choose = Console.ReadLine();
            ans.Add(new Answer(i+1, choose));
        }
        Console.WriteLine("enter correct answer id 1-2-3 is a choice: ");
        int ansid = Convert.ToInt32(Console.ReadLine());
        return new MCQ(header, body, mark, ansid, ans);
    }
}
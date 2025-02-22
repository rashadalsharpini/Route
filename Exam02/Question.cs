namespace ConsoleApp2;

public abstract class Question
{
    public string Header { get; set; }
    public string Body { get; set; }
    public double Mark { get; set; }
    public List<Answer> answers { get; set; } = new();
    public int CorrectAnswerId { get; set; }

    public Question(string header, string body, double mark)
    {
        Header = header;
        Body = body;
        Mark = mark;
    }

    public abstract void display();
}
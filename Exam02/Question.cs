namespace ConsoleApp2;

public abstract class Question
{
    public string Header { get; set; }
    public string Body { get; set; }
    public int Mark { get; set; }
    public List<Answer> choices { get; set; } = new();
    public int CorrectAnswerId { get; set; }

    public Question(string header, string body, int mark, int correctAnswerId)
    {
        Header = header;
        Body = body;
        Mark = mark;
        CorrectAnswerId = correctAnswerId;
    }

    public abstract void display();
}
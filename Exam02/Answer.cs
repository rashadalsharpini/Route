namespace ConsoleApp2;

public class Answer
{
    public int AnswerId { get; set; }
    public string? AnswerText { get; set; }

    public Answer(int id, string? text)
    {
        AnswerId = id;
        AnswerText = text;
    }

    public override string ToString()
    {
        return $"{AnswerId}- {AnswerText}";
    }
}
namespace ConsoleApp2;

public abstract class Exam
{
    public int Time { get; set; }
    public int NumberOfQuestions { get; set; }
    public List<Question> Questions { get; set; } = new();

    public Exam(int time, int numberOfQuestions)
    {
        Time = time;
        NumberOfQuestions = numberOfQuestions;
        Questions = new List<Question>();
    }

    public abstract void CreateExam();
    public abstract void showexam();
}
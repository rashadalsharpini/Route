namespace ConsoleApp2;

public class Subject
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public Exam Exam { get; set; }

    public Subject(int id, string name, Exam exam)
    {
        SubjectId = id;
        SubjectName = name;
        Exam = exam;
    }
}
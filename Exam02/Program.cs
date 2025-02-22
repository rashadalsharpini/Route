namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Subject subject = new Subject(1, "Math", new FinalExam(60, 2));
        subject.Exam.Questions.Add(new TrueFalse("Q1", "5 is a prime number?", 5) { CorrectAnswerId = 1 });
        subject.Exam.Questions.Add(new MCQ("Q2", "What is 2 + 2?", 5, new List<Answer>
        {
            new Answer(1, "3"),
            new Answer(2, "4"),
            new Answer(3, "5")
        }) { CorrectAnswerId = 2 });
        
        subject.Exam.showexam();
    }
}
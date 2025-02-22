namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Subject subject = new Subject(1, "Math", new FinalExam(60, 2));
        
        
        
        
        
        subject.Exam.showexam();
        
    }
}
using ConsoleApp1.DbContexts;
using ConsoleApp1.models;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        using ITIDbContext db = new ITIDbContext();
        student st = new student()
        {
            address = "123 Main St",
            age = 22,
            department_id = 1,
            fname = "John",
            lname = "Doe",
        };
        
        //insert
        db.Add(st);
        Console.WriteLine(db.Entry(st).State);
        db.SaveChanges();
        Console.WriteLine(db.Entry(st).State);
        //retrive
        var st2 = db.students.FirstOrDefault(s => s.id == 1);
        Console.WriteLine(st);
        //update
        st2.age = 23;
        db.SaveChanges();
        //drop
        db.Remove(st2);
        db.SaveChanges();
    }
}
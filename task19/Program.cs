using EF03.DbContexts;

namespace EF03;

class Program
{
    static void Main(string[] args)
    {
        using ItiDbContext db = new ItiDbContext();
        Console.WriteLine("Hello, World!");
    }
}
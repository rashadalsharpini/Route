using ConsoleApp2.DbContexts;

namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        using ITIDbContext db = new ITIDbContext();
    }
}
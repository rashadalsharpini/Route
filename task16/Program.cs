using LinqDemo;
using static LinqDemo.ListGenerator;
 
namespace ConsoleApp1;

class Program
{
    
    static void Main(string[] args)
    {
        var q1 = CustomerList
            .Where(c => c.City == "Washington")
            .SelectMany(c => c.Orders)
            .Take(3);

        var q2 = CustomerList
            .Where(c => c.City == "Washington")
            .Skip(2)
            .SelectMany(c => c.Orders);

        int[] num = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
        var q3 = num.TakeWhile((i, index) => i >= index);
        var q4 = num.SkipWhile(i => i % 3 != 0);
        var q5 = num.SkipWhile((i, index) => i >= index);
        
        List<int> numbers = new List<int> {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};

        var groupedByRemainder = numbers.GroupBy(n => n % 5);

        foreach (var group in groupedByRemainder)
        {
            Console.WriteLine($"Numbers with remainder {group.Key} when divided by 5:");
            Console.WriteLine(string.Join(", ", group));
        }
        var words = System.IO.File.ReadAllLines("dictionary_english.txt");

        var groupedByFirstLetter = words.GroupBy(word => word[0]);

        foreach (var group in groupedByFirstLetter)
        {
            Console.WriteLine($"Words starting with '{group.Key}':");
            Console.WriteLine(string.Join(", ", group));
        }
        
        string[] arr = { "from", "salt", "earn", "last", "near", "form" };

        var groupedAnagrams = arr.GroupBy(word => new string(word.OrderBy(c => c).ToArray()));

        foreach (var group in groupedAnagrams)
        {
            Console.WriteLine("Anagram Group:");
            Console.WriteLine(string.Join(", ", group));
        }


    }
}


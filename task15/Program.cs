using LinqDemo;
using static LinqDemo.ListGenerator;
 
namespace ConsoleApp1;

class Program
{
    
    static void Main(string[] args)
    {
        var products = ProductList;
            var customers = CustomerList;

            // LINQ - Element Operators
            var firstOutOfStock = products.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine($"First product out of stock: {firstOutOfStock?.ProductName ?? "None"}");

            var firstExpensiveProduct = products.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine($"First product with price > 1000: {firstExpensiveProduct?.ProductName ?? "None"}");

            var secondGreaterThanFive = new[] { 1, 3, 7, 9, 2, 6 }.Where(n => n > 5).Skip(1).FirstOrDefault();
            Console.WriteLine($"Second number greater than 5: {secondGreaterThanFive}");

            // LINQ - Aggregate Operators
            var oddNumbersCount = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.Count(n => n % 2 != 0);
            Console.WriteLine($"Count of odd numbers: {oddNumbersCount}");

            var customerOrderCounts = customers.Select(c => new { c.CustomerName, OrderCount = c.Orders.Length });
            foreach (var entry in customerOrderCounts)
                Console.WriteLine($"{entry.CustomerName} has {entry.OrderCount} orders");

            var categoryProductCounts = products.GroupBy(p => p.Category)
                                                .Select(g => new { Category = g.Key, Count = g.Count() });
            foreach (var entry in categoryProductCounts)
                Console.WriteLine($"Category: {entry.Category}, Product Count: {entry.Count}");

            var totalNumbers = new[] { 1, 2, 3, 4, 5 }.Sum();
            Console.WriteLine($"Total of numbers: {totalNumbers}");

            // LINQ - Set Operators
            var uniqueCategories = products.Select(p => p.Category).Distinct();
            Console.WriteLine("Unique Categories: " + string.Join(", ", uniqueCategories));

            var productFirstLetters = products.Select(p => p.ProductName[0]);
            var customerFirstLetters = customers.Select(c => c.CustomerName[0]);
            var uniqueFirstLetters = productFirstLetters.Union(customerFirstLetters);
            Console.WriteLine("Unique first letters: " + string.Join(", ", uniqueFirstLetters));

            var commonFirstLetters = productFirstLetters.Intersect(customerFirstLetters);
            Console.WriteLine("Common first letters: " + string.Join(", ", commonFirstLetters));

            var exclusiveProductFirstLetters = productFirstLetters.Except(customerFirstLetters);
            Console.WriteLine("Product first letters not in customers: " + string.Join(", ", exclusiveProductFirstLetters));

            var lastThreeCharacters = products.Select(p => p.ProductName[^3..])
                                              .Union(customers.Select(c => c.CustomerName[^3..]));
            Console.WriteLine("Last three characters in names: " + string.Join(", ", lastThreeCharacters));

            // LINQ - Quantifiers
            var dictionaryWords = System.IO.File.ReadAllLines("dictionary_english.txt");
            var containsEi = dictionaryWords.Any(word => word.Contains("ei"));
            Console.WriteLine($"Any word contains 'ei': {containsEi}");

            var categoriesWithOutOfStock = products.GroupBy(p => p.Category)
                                                   .Where(g => g.Any(p => p.UnitsInStock == 0));
            foreach (var entry in categoriesWithOutOfStock)
                Console.WriteLine($"Category with at least one out-of-stock product: {entry.Key}");

            var categoriesWithAllInStock = products.GroupBy(p => p.Category)
                                                   .Where(g => g.All(p => p.UnitsInStock > 0));
            foreach (var entry in categoriesWithAllInStock)
                Console.WriteLine($"Category with all products in stock: {entry.Key}");
    }
}


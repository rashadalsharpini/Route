using LinqDemo;
using static LinqDemo.ListGenerator;
 
namespace ConsoleApp1;

class Program
{
    
    static void Main(string[] args)
    {
            // LINQ - Element Operators
            //1
            var firstOutOfStock = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine($"First product out of stock: {firstOutOfStock?.ProductName ?? "None"}");
            //2
            var firstExpensiveProduct = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine($"First product with price > 1000: {firstExpensiveProduct?.ProductName ?? "None"}");
            //3
            var secondGreaterThanFive = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }.Where(n => n > 5).Skip(1).FirstOrDefault();
            Console.WriteLine($"Second number greater than 5: {secondGreaterThanFive}");

            // LINQ - Aggregate Operators
            //1
            var oddNumbersCount = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }.Count(n => n % 2 != 0);
            Console.WriteLine($"Count of odd numbers: {oddNumbersCount}");
            //2
            var customerOrderCounts = CustomerList.Select(c => new { c.CustomerName, OrderCount = c.Orders.Length });
            foreach (var entry in customerOrderCounts)
                Console.WriteLine($"{entry.CustomerName} has {entry.OrderCount} orders");
            //3
            var categoryProductCounts = ProductList.GroupBy(p => p.Category)
                                                .Select(g => new { Category = g.Key, Count = g.Count() });
            foreach (var entry in categoryProductCounts)
                Console.WriteLine($"Category: {entry.Category}, Product Count: {entry.Count}");
            //4
            var totalNumbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }.Sum();
            Console.WriteLine($"Total of numbers: {totalNumbers}");
            //5
            var dictionaryWords = System.IO.File.ReadAllLines("dictionary_english.txt");
            var totalCharacters = dictionaryWords.Sum(word => word.Length);
            Console.WriteLine($"Total characters in dictionary: {totalCharacters}");
            //6
            var shortestWordLength = dictionaryWords.Min(word => word.Length);
            Console.WriteLine($"Shortest word length: {shortestWordLength}");
            //7
            var longestWordLength = dictionaryWords.Max(word => word.Length);
            Console.WriteLine($"Longest word length: {longestWordLength}");
            //8
            var averageWordLength = dictionaryWords.Average(word => word.Length);
            Console.WriteLine($"Average word length: {averageWordLength:F2}");
            //9
            var totalUnitsPerCategory = ProductList.GroupBy(p => p.Category)
                                                .Select(g => new { Category = g.Key, TotalUnits = g.Sum(p => p.UnitsInStock) });
            foreach (var entry in totalUnitsPerCategory)
                Console.WriteLine($"Category: {entry.Category}, Total Units: {entry.TotalUnits}");
            //10
            var cheapestPricePerCategory = ProductList.GroupBy(p => p.Category)
                                                   .Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });
            foreach (var entry in cheapestPricePerCategory)
                Console.WriteLine($"Category: {entry.Category}, Cheapest Price: {entry.CheapestPrice}");
            //11
            var cheapestProductsPerCategory = ProductList.GroupBy(p => p.Category)
                                                       .Select(g => new { Category = g.Key, CheapestProducts = g.Where(p => p.UnitPrice == g.Min(p2 => p2.UnitPrice)) });
            foreach (var entry in cheapestProductsPerCategory)
                Console.WriteLine($"Category: {entry.Category}, Cheapest Products: {string.Join(", ", entry.CheapestProducts.Select(p => p.ProductName))}");
            //12
            var mostExpensivePricePerCategory = ProductList.GroupBy(p => p.Category)
                                                        .Select(g => new { Category = g.Key, MaxPrice = g.Max(p => p.UnitPrice) });
            foreach (var entry in mostExpensivePricePerCategory)
                Console.WriteLine($"Category: {entry.Category}, Most Expensive Price: {entry.MaxPrice}");
            //13
            var mostExpensiveProductsPerCategory = ProductList.GroupBy(p => p.Category)
                                                           .Select(g => new { Category = g.Key, ExpensiveProducts = g.Where(p => p.UnitPrice == g.Max(p2 => p2.UnitPrice)) });
            foreach (var entry in mostExpensiveProductsPerCategory)
                Console.WriteLine($"Category: {entry.Category}, Most Expensive Products: {string.Join(", ", entry.ExpensiveProducts.Select(p => p.ProductName))}");
            //14
            var averagePricePerCategory = ProductList.GroupBy(p => p.Category)
                                                  .Select(g => new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) });
            foreach (var entry in averagePricePerCategory)
                Console.WriteLine($"Category: {entry.Category}, Average Price: {entry.AveragePrice:F2}");

            // LINQ - Set Operators
            //1
            var uniqueCategories = ProductList.Select(p => p.Category).Distinct();
            Console.WriteLine("Unique Categories: " + string.Join(", ", uniqueCategories));
            //2
            var productFirstLetters = ProductList.Select(p => p.ProductName[0]);
            var customerFirstLetters = CustomerList.Select(c => c.CustomerName[0]);
            var uniqueFirstLetters = productFirstLetters.Union(customerFirstLetters);
            Console.WriteLine("Unique first letters: " + string.Join(", ", uniqueFirstLetters));
            //3
            var commonFirstLetters = productFirstLetters.Intersect(customerFirstLetters);
            Console.WriteLine("Common first letters: " + string.Join(", ", commonFirstLetters));
            //4
            var exclusiveProductFirstLetters = productFirstLetters.Except(customerFirstLetters);
            Console.WriteLine("Product first letters not in customers: " + string.Join(", ", exclusiveProductFirstLetters));
            //5
            var lastThreeCharacters = ProductList.Select(p => p.ProductName[^3..])
                                              .Union(CustomerList.Select(c => c.CustomerName[^3..]));
            Console.WriteLine("Last three characters in names: " + string.Join(", ", lastThreeCharacters));

            // LINQ - Quantifiers
            //1
            dictionaryWords = System.IO.File.ReadAllLines("dictionary_english.txt");
            var containsEi = dictionaryWords.Any(word => word.Contains("ei"));
            Console.WriteLine($"Any word contains 'ei': {containsEi}");
            //2
            var categoriesWithOutOfStock = ProductList.GroupBy(p => p.Category)
                                                   .Where(g => g.Any(p => p.UnitsInStock == 0));
            foreach (var entry in categoriesWithOutOfStock)
                Console.WriteLine($"Category with at least one out-of-stock product: {entry.Key}");
            //3
            var categoriesWithAllInStock = ProductList.GroupBy(p => p.Category)
                                                   .Where(g => g.All(p => p.UnitsInStock > 0));
            foreach (var entry in categoriesWithAllInStock)
                Console.WriteLine($"Category with all products in stock: {entry.Key}");
    }
}


using LinqDemo;
using static LinqDemo.ListGenerator;

namespace ConsoleApp1;

class Program
{
    
    static void Main(string[] args)
    {
        # region LINQ - Restriction Operators
        //1
        var result = from v in ProductList 
            where v.UnitsInStock == 0 select v;
        result = ProductList.Where(pro => pro.UnitsInStock == 0);
        foreach (var pro in result)
        {
            Console.WriteLine(pro);
        }
        //2
        var result2 = from v in ProductList
            where v.UnitsInStock != 0 && v.UnitPrice > 3
            select v;
        result2 = ProductList.Where(pro=> pro.UnitsInStock != 0 && pro.UnitPrice > 3);
        foreach (var product in result2)
        {
            Console.WriteLine(product);
        }
        //3
        // didn't understand it
        #endregion
        #region LINQ - Ordering Operators
        //1
        var result3 = from v in ProductList
            orderby v.ProductName select v;
        result3 = ProductList.OrderBy(pro => pro.ProductName);
        Console.WriteLine(string.Join("-->\n", result3));
        //2
        String [] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
        Array.Sort(Arr, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine(string.Join(", ", Arr));
        //3
        var result4 = from v in ProductList
            orderby v.UnitsInStock descending select v;
        result4 = ProductList.OrderByDescending(pro => pro.UnitsInStock);
        Console.WriteLine(string.Join("\n", result4));
        //4
        string [] Arr1 = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        var sortedArr = Arr1.OrderBy(s => s.Length).ThenBy(s => s);
        Console.WriteLine(string.Join("\n", sortedArr));
        sortedArr = from v in Arr1
            orderby v.Length , v select v;
        Console.WriteLine(string.Join("\n", sortedArr));
        //5
        String [] Arr2 = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
        sortedArr = Arr2.OrderBy(s => s.Length).ThenBy(s => s, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine(string.Join("\n", sortedArr));
        sortedArr = from v in Arr2
            orderby v.Length , v.ToLower() select v;
        Console.WriteLine(string.Join("\n", sortedArr));
        //6
        var sortedProduct = ProductList.OrderBy(s => s.Category).ThenByDescending(s => s.UnitPrice);
        Console.WriteLine(string.Join("\n", sortedProduct));
        sortedProduct = from v in ProductList
            orderby v.Category, v.UnitPrice descending select v;
        Console.WriteLine(string.Join("\n", sortedProduct));
        //7
        sortedArr = Arr2.OrderBy(s => s.Length).ThenByDescending(s => s, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine(string.Join("\n", sortedArr));
        sortedArr = from v in Arr2
            orderby v.Length , v.ToLower() descending select v;
        Console.WriteLine(string.Join("\n", sortedArr));
        //8
        string[] Arr3 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var result6 = Arr3.Where(s => s.Length > 1 && s[1] == 'i').Reverse();
        Console.WriteLine(string.Join("\n", result6));
        result6 = (from v in Arr3
            where v.Length > 1 && v[1] == 'i'
            select v).Reverse();
        Console.WriteLine(string.Join("\n", result6));

        #endregion
        #region LINQ – Transformation Operators
        //1
        var result5 = from v in ProductList
            select v.ProductName;
        result5 = ProductList.Select(v => v.ProductName);
        //2
        String [] words = {"aPPLE", "BlUeBeRrY", "cHeRry"};
        var result8 = words.Select(word => new
        {
            original = word,
            lowercase = word.ToLower(),
            uppercase = word.ToUpper()
        });
        //3
        var result9 = from v in ProductList
            select new {price=v.UnitPrice};
        result9 = ProductList.Select(v=>new {price=v.UnitPrice});
        //4
        int[] Arr4 = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];
        var res = Arr4.Select((num, index) => new { Number = num, inplace = index == num });
        Console.WriteLine(string.Join("\n", res));
        //5
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };

        var pairs = numbersA
            .SelectMany(a => numbersB.Where(b => a < b)
                .Select(b => (a, b))); 
        pairs = from a in numbersA
            from b in numbersB
            where a < b
            select (a, b);

        foreach (var pair in pairs)
        {
            Console.WriteLine(pair);
        }
        //6
        var res2 = CustomerList.Select(cus => cus.Orders.Select(order => order.Total < 500));
        var res4 = from cus in CustomerList
            from order in cus.Orders
            where order.Total < 500
                select order;
        Console.WriteLine(string.Join("\n", res4));
        //7
        var res5 = CustomerList.Select(cus => cus.Orders.Select(order => order.OrderDate >= new DateTime(1998, 12 , 31)));
        #endregion
    }
}

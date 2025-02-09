using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string[] Authors { get; set; }
    public DateTime PublicationDate { get; set; }
    public decimal Price { get; set; }

    public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
    {
        ISBN = _ISBN;
        Title = _Title;
        Authors = _Authors;
        PublicationDate = _PublicationDate;
        Price = _Price;
    }

    public override string ToString()
    {
        return $"ISBN: {ISBN}, Title: {Title}, Authors: {string.Join(", ", Authors)}, Publication Date: {PublicationDate.ToShortDateString()}, Price: {Price:C}";
    }
}

public class BookFunctions
{
    public static string GetTitle(Book B) => B.Title;

    public static string GetAuthors(Book B) => string.Join(", ", B.Authors);

    public static string GetPrice(Book B) => B.Price.ToString("C");
}

// Part 02: Delegates and ProcessBooks Method
public delegate string BookDelegate(Book b);

public class LibraryEngine
{
    public static void ProcessBooks(List<Book> bList, BookDelegate func)
    {
        foreach (Book B in bList)
        {
            Console.WriteLine(func(B));
        }
    }
}

class Program
{
    static void Main()
    {
        List<Book> books = new List<Book>
        {
            new Book("12345", "C# Programming", new string[]{"John Doe"}, new DateTime(2020, 1, 1), 49.99m),
            new Book("67890", "Advanced C#", new string[]{"Jane Smith"}, new DateTime(2021, 5, 10), 59.99m)
        };

        // Using User-Defined Delegate
        LibraryEngine.ProcessBooks(books, BookFunctions.GetTitle);
        LibraryEngine.ProcessBooks(books, BookFunctions.GetAuthors);

        // Using Built-in Delegate
        LibraryEngine.ProcessBooks(books, new Func<Book, string>(BookFunctions.GetPrice));

        // Using Anonymous Method
        LibraryEngine.ProcessBooks(books, delegate (Book b) { return b.ISBN; });

        // Using Lambda Expression
        LibraryEngine.ProcessBooks(books, b => b.PublicationDate.ToShortDateString());
    }
}

// Part 03: List Methods Implementation
public static class ListExtensions
{
    public static bool Exists<T>(this List<T> list, Predicate<T> match)
    {
        foreach (var item in list)
        {
            if (match(item)) return true;
        }
        return false;
    }

    public static T Find<T>(this List<T> list, Predicate<T> match)
    {
        foreach (var item in list)
        {
            if (match(item)) return item;
        }
        return default;
    }

    public static List<T> FindAll<T>(this List<T> list, Predicate<T> match)
    {
        List<T> result = new List<T>();
        foreach (var item in list)
        {
            if (match(item)) result.Add(item);
        }
        return result;
    }

    public static int FindIndex<T>(this List<T> list, Predicate<T> match)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (match(list[i])) return i;
        }
        return -1;
    }

    public static T FindLast<T>(this List<T> list, Predicate<T> match)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (match(list[i])) return list[i];
        }
        return default;
    }

    public static int FindLastIndex<T>(this List<T> list, Predicate<T> match)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (match(list[i])) return i;
        }
        return -1;
    }

    public static void ForEach<T>(this List<T> list, Action<T> action)
    {
        foreach (var item in list)
        {
            action(item);
        }
    }

    public static bool TrueForAll<T>(this List<T> list, Predicate<T> match)
    {
        foreach (var item in list)
        {
            if (!match(item)) return false;
        }
        return true;
    }
}

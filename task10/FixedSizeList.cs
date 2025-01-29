namespace ConsoleApp1;

public class FixedSizeList<T>
{
    private T[] items;
    private int count;

    public FixedSizeList(int capacity)
    {
        if (capacity <= 0) throw new Exception("Capacity must be greater than zero.");
        items = new T[capacity];
        count = 0;
    }

    public void Add(T item)
    {
        if (count >= items.Length) throw new Exception("List is full.");
        items[count++] = item;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count) throw new Exception("Invalid index.");
        return items[index];
    }
}
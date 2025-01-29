Console.WriteLine("run");
int[] a = new[] { 1, 2, 3, 4, 5, 6 };
int[] b = reverse(a);
foreach (var item in b)
    Console.WriteLine(item);
Console.WriteLine("-----------");
int[] c = returnEvenList(a);
foreach (var item in c)
    Console.WriteLine(item);




static T[] returnEvenList<T>(T[] a) where T : IConvertible
{
    // it wouldn't run probably when i used a normal array
    List<T> evenList = new List<T>(); 
    foreach (T item in a)
        if (Convert.ToInt32(item) % 2 == 0)
            evenList.Add(item);
    return evenList.ToArray();
}
static T[] ReturnEvenList<T>(T[] a) where T : struct, IConvertible
{
    List<T> evenList = new List<T>(); 

    foreach (T item in a)
    {
        if (Convert.ToInt32(item) % 2 == 0)  
        {
            evenList.Add(item);
        }
    }

    return evenList.ToArray();
}

static T[] reverse<T>(T[] a)
{
    T[] b = new T[a.Length];
    for (int i = 0, j = a.Length - 1; i < a.Length; i++, j--)
    {
        b[j] = a[i];
    }
    return b;
}
static void OptimizedBubbleSort(int[] arr)
{
    int n = arr.Length;
    bool swapped;
    for (int i = 0; i < n - 1; i++)
    {
        swapped = false;
        for (int j = 0; j < n - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                swapped = true;
            }
        }
        if (!swapped)
            break;
    }
}

static int FirstNonRepeatingChar(string str)
{
    Dictionary<char, int> charCount = new Dictionary<char, int>();
    foreach (char c in str)
    {
        if (charCount.ContainsKey(c))
            charCount[c]++;
        else
            charCount[c] = 1;
    }
    for (int i = 0; i < str.Length; i++)
    {
        if (charCount[str[i]] == 1)
            return i;
    }
    return -1;
}

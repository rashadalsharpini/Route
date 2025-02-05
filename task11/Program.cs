//1

using System.Collections;

int n = Convert.ToInt32(Console.ReadLine());
int tt = Convert.ToInt32(Console.ReadLine());
int[] arr = new int[n];
for (int i = 0; i < n; i++)
    arr[i] = Convert.ToInt32(Console.ReadLine());

Array.Sort(arr);
int dump, count =0;
while (tt-->0)
{
    dump = Convert.ToInt32(Console.ReadLine());
    int index = Array.BinarySearch(arr, dump);
    if (index < 0) index = ~index;
    else index++;
    Console.WriteLine(n - index);
}
Array.Clear(arr, 0, n);
/////////////////////////////////
//2
n = Convert.ToInt32(Console.ReadLine());
arr = new int[n];
int l =0, r= n-1;
bool flag = true;
while (l < r)
{
    if (arr[l] != arr[r])
    {
        flag = false;
        break;
    }
}
if(flag) Console.WriteLine("Palindrome");
else Console.WriteLine("Not Palindrome");
//////////////////////////////
// 3
Queue<int> qq = new Queue<int>();
qq.Enqueue(1);
qq.Enqueue(2);
qq.Enqueue(3);
qq.Enqueue(4);
qq.Enqueue(5);
foreach (int item in qq)
    Console.WriteLine(item);

qq = reverseQueue(qq);
foreach (int item in qq)
    Console.WriteLine(item);

Queue<int> reverseQueue(Queue<int> qq)
{
    Stack<int> ss = new Stack<int>();
    while (qq.Count > 0)
    {
        ss.Push(qq.Dequeue());
    }
    while (ss.Count > 0)
    {
        qq.Enqueue(ss.Pop());
    }
    return qq;
}

/////////////////////////
// 4
string s = Console.ReadLine();
Console.WriteLine(IsBalanced(s)? "Balanced" : "Not Balanced");

static bool IsBalanced(string s)
{
    Stack<char> stack = new Stack<char>();

    foreach (char c in s)
    {
        if (c == '(' || c == '[' || c == '{')
        {
            stack.Push(c);
        }
        else if (c == ')' || c == ']' || c == '}')
        {
            if (stack.Count == 0) return false; 
            char top = stack.Pop();
            if ((c == ')' && top != '(') ||
                (c == ']' && top != '[') ||
                (c == '}' && top != '{'))
                return false; 
        }
    }

    return stack.Count == 0;
}
/////////////////////////////////////////////////
// 5
int[] arr1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Console.WriteLine(string.Join(" ", arr1.Distinct().ToArray()));
//////////////////////////////////////
// 6


int[] arr2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
arr2 = noOdd(arr2);
Console.WriteLine(string.Join(" ", arr2));

int[] noOdd(int[] arr1)
{
    return arr1.Where(x => x % 2 == 0).ToArray(); // the auto complete is great :)
}
////////////////////////////////
// 7
Queue q = new Queue();
q.Enqueue(1);
q.Enqueue("1");
q.Enqueue(true);
q.Enqueue(3.4);
////////////////////////////
// 8
Stack<int> ss = new Stack<int>();
ss.Push(1);
ss.Push(2);
ss.Push(3);
ss.Push(4);
ss.Push(5);
ss.Push(6);
int searchFOR = 2;
count = 0;
flag = false;
foreach (int i in ss)
{
    count++;
    if (searchFOR == i)
        flag = true;
}

if (flag)
    Console.WriteLine($"target was found successfully and count is:{count}");
else
    Console.WriteLine("target was not found");
/////////////////////////////////////
/// 9
int[] arr11 = [ 1, 2, 3, 4, 4 ];
int[] arr21 = [ 10, 4, 4 ];
List<int> result = Intersection(arr11, arr21);
Console.WriteLine("[" + string.Join(",", result) + "]");
static List<int> Intersection(int[] arr1, int[] arr2)
{
    List<int> result = new List<int>();
    Dictionary<int, int> map = new Dictionary<int, int>();
    foreach (int num in arr1)
    {
        if (map.ContainsKey(num))
            map[num]++;
        else
            map[num] = 1;
    }
    foreach (int num in arr2)
    {
        if (map.ContainsKey(num) && map[num] > 0)
        {
            result.Add(num);
            map[num]--;
        }
    }

    return result;
}
///////////////////////////////////
/// 10
List<int> nums = new List<int> { 1, 2, 3, 7, 5 };
int target = 12;
        
List<int> sublist = FindSublist(nums, target);
if (sublist.Count > 0)
    Console.WriteLine("[" + string.Join(", ", sublist) + "]");
else
    Console.WriteLine("No sublist found.");
static List<int> FindSublist(List<int> nums, int target)
{
    int sum = 0;
    int start = 0;
        
    for (int end = 0; end < nums.Count; end++)
    {
        sum += nums[end];
        while (sum > target && start <= end)
        {
            sum -= nums[start];
            start++;
        }
        if (sum == target)
            return nums.GetRange(start, end - start + 1);
    }

    return new List<int>();
}
//////////////////////////////////////////
/// 11
Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
int k = 3;

ReverseFirstKElements(queue, k);
        
Console.WriteLine("[" + string.Join(", ", queue) + "]");
static void ReverseFirstKElements(Queue<int> queue, int k)
{
    Stack<int> stack = new Stack<int>();
    for (int i = 0; i < k; i++)
        stack.Push(queue.Dequeue());

    while (stack.Count > 0)
        queue.Enqueue(stack.Pop());

    int remaining = queue.Count - k;
    for (int i = 0; i < remaining; i++)
        queue.Enqueue(queue.Dequeue());
}

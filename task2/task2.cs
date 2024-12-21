//1
Console.Write("enter number: ");
int num=Convert.ToInt32(Console.ReadLine());
Console.WriteLine(num%3==0&&num%4==0?"YES":"NO");
//2
Console.Write("enter number: ");
num=Convert.ToInt32(Console.ReadLine());
Console.WriteLine(num>0?"positive":"negative");
//3
int[] nums=new int[3];
int MIN = int.MaxValue;
int MAX = int.MinValue;
for (int i = 0; i < 3; i++)
{
    nums[i]=Convert.ToInt32(Console.ReadLine());
    MIN = nums[i]<MIN?nums[i]:MIN;
    MAX = nums[i]>MAX?nums[i]:MAX;
}
Console.WriteLine($"max: {MAX}, min: {MIN}");
//4
Console.Write("enter number: ");
num=Convert.ToInt32(Console.ReadLine());
Console.WriteLine(num%2==0?"even":"odd");
//5
Console.Write("enter char: ");
char c= char.ToLower(Convert.ToChar(Console.ReadLine()));
Console.WriteLine(c=='a'||c=='e'||c=='i'||c=='o'||c=='u'?"vowel":"consonant");
//6
Console.Write("enter number: ");
num=Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < num; i++)
    Console.Write(i+1 + " ");

//7
Console.Write("\nenter number: ");
num=Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < 12; i++)
    Console.Write((i + 1)*num + " ");
//8
Console.Write("\nenter number: ");
num=Convert.ToInt32(Console.ReadLine());
for (int i = 1; i <= num; i++)
    Console.Write(i%2==0?i:" ");
    
//9
Console.Write("\nenter number: ");
num=Convert.ToInt32(Console.ReadLine());
Console.Write("enter number: ");
int num2=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("power: " + Math.Pow(num,num2));
//10
num = 0;
for (int i = 0; i < 5; i++)
    num+=Convert.ToInt32(Console.ReadLine());

Console.WriteLine("total marks: "+num);
Console.WriteLine("average marks: "+num/5);
Console.WriteLine("percentage: "+ ((double)num / 500)*100);
//11
Console.Write("enter month: ");
num=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("days in month"+ DateTime.DaysInMonth(2024, num));
//12
Console.WriteLine("Simple Calculator");
Console.WriteLine("Available Operations: +, -, *, /");
Console.Write("Enter the first number: ");
double num1 = double.Parse(Console.ReadLine());

Console.Write("Enter an operator (+, -, *, /): ");
char operation = char.Parse(Console.ReadLine());

Console.Write("Enter the second number: ");
double num3 = double.Parse(Console.ReadLine());

double result = 0;
bool isValidOperation = true;

switch (operation)
{
    case '+':
        result = num1 + num3;
        break;
    case '-':
        result = num1 - num3;
        break;
    case '*':
        result = num1 * num3;
        break;
    case '/':
        if (num3 != 0)
            result = num1 / num3;
        else
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            isValidOperation = false;
        }
        break;
    default:
        Console.WriteLine("Error: Invalid operator.");
        isValidOperation = false;
        break;
}

if (isValidOperation)
    Console.WriteLine($"Result: {num1} {operation} {num3} = {result}");
    
//13
Console.Write("enter string: ");
string s=Console.ReadLine();
string rev=new string(s.Reverse().ToArray());
Console.WriteLine(rev);
//14
Console.Write("enter number: ");
s=Console.ReadLine();
rev=new string(s.Reverse().ToArray());
Console.WriteLine(rev);
//15

Console.Write("enter start: ");
int start=Convert.ToInt32(Console.ReadLine());
Console.Write("enter end: ");
int end=Convert.ToInt32(Console.ReadLine());
for (int i = start; i <= end; i++)
    Console.Write(IsPrime(i)?i+" ":"");
//16
Console.Write("\nenter number: ");
num=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("binary: "+ Convert.ToString(num,2));
//17
Console.Write("enter x1: ");
double x1 = Convert.ToDouble(Console.ReadLine());
Console.Write("enter y1: ");
double y1 = Convert.ToDouble(Console.ReadLine());
Console.Write("enter x2: ");
double x2 = Convert.ToDouble(Console.ReadLine());
Console.Write("enter y2: ");
double y2 = Convert.ToDouble(Console.ReadLine());
Console.Write("enter x3: ");
double x3 = Convert.ToDouble(Console.ReadLine());
Console.Write("enter y3: ");
double y3 = Convert.ToDouble(Console.ReadLine());
if((y2-y1)*(x3-x2)==(y3-y2)*(x2-x1))
    Console.WriteLine("the points are on a straight line");
else 
    Console.WriteLine("the points are not on a line");
//18
Console.Write("enter hours: ");
int time = Convert.ToInt32(Console.ReadLine());
if (time<=3)
    Console.WriteLine("highly efficient employee");
else if(time<=4)
    Console.WriteLine("the employee should be instructed to increase his speed");
else if(time<=5)
    Console.WriteLine("the employee should be provided with a training ot enhance their speed");
else 
    Console.WriteLine("the employee should leave the company");
//19
Console.Write("enter number: ");
num = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < num; i++)
{
    for (int j = 0; j < num; j++)
        Console.Write(i == j ? "1 " : "0 ");
    Console.WriteLine();
}
//20
Console.Write("enter size of the array: ");
num = Convert.ToInt32(Console.ReadLine());
int sum = 0;
int[] arr=new int[num];
for (int i = 0; i < num; i++)
{
    arr[i] = Convert.ToInt32(Console.ReadLine());
    sum += arr[i];
}
Console.WriteLine($"sum: {sum}");
//21
Console.Write("enter size of the array1: ");
num = Convert.ToInt32(Console.ReadLine());
int[] arr2 = new int[num];
for (int i = 0; i < num; i++)
    arr2[i] = Convert.ToInt32(Console.ReadLine());
Console.Write("enter size of the array2: ");
num2 = Convert.ToInt32(Console.ReadLine());
int[] arr3 = new int[num2];
for (int i = 0; i < num2; i++)
    arr3[i] = Convert.ToInt32(Console.ReadLine());
int[] arr4 = new int[num+num2];
for (int i = 0; i < num; i++)
    arr4[i] = arr2[i];
for (int i = 0; i < num2; i++)
    arr4[i+num] = arr3[i];
Array.Sort(arr4);
for (int i = 0; i < num+num2; i++)
    Console.WriteLine(arr4[i]);
//22
Dictionary<int, int> freqMP=new Dictionary<int, int>();
foreach (int i in arr4)
{
    if(freqMP.ContainsKey(i))
        freqMP[i]++;
    else 
        freqMP[i]=1;
}

foreach (var i in freqMP)
{
    Console.WriteLine($"{i.Key}: {i.Value}");
}
//23
MIN = int.MaxValue;
MAX = int.MinValue;
Console.Write("enter size of the array: ");
num = Convert.ToInt32(Console.ReadLine());
int[] arr5=new int[num];
for (int i = 0; i < num; i++)
{
    arr5[i] = Convert.ToInt32(Console.ReadLine());
    MIN = Math.Min(MIN, arr5[i]);
    MAX = Math.Max(MIN, arr5[i]);
}
Console.WriteLine($"MIN: {MIN}, MAX: {MAX}");
//24
int secondLargest = int.MinValue;
for (int i = 0; i < num; i++)
{
    if (num < MAX && num > secondLargest)
    {
        secondLargest = num;
    }
}
Console.WriteLine($"the second largest: {secondLargest}");
//25
Console.Write("enter size of the array: ");
num = Convert.ToInt32(Console.ReadLine());
int[] arr6 = new int[num];
for (int i = 0; i < num; i++)
{
    arr6[i] = Convert.ToInt32(Console.ReadLine());
}

int maxDistance = 0;
for (int i = 0; i < num; i++)
{
    for (int j = i+1; j < num; j++)
    {
        if (arr6[i]==arr6[j])
        {
            int distance = j - i;
            maxDistance=distance>maxDistance?distance+1:maxDistance+1;
        }
    }
}
Console.WriteLine(maxDistance);
//26
Console.WriteLine("enter sentence: ");
string sentence = Console.ReadLine();
string reversed = string.Join(" ", sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
Console.WriteLine(reversed);
//27
Console.Write("Enter the number of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the number of columns: ");
int cols = Convert.ToInt32(Console.ReadLine());
int[,] array1 = new int[rows, cols];
int[,] array2 = new int[rows, cols];

Console.WriteLine("Enter elements for the first array:");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        Console.Write($"Element [{i},{j}]: ");
        array1[i, j] = Convert.ToInt32(Console.ReadLine());
    }
}

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        array2[i, j] = array1[i, j];
    }
}

Console.WriteLine("Elements of the second array:");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        Console.Write(array2[i, j] + " ");
    }
    Console.WriteLine();
}
//28
Console.Write("Enter the size of the array: ");
int size = Convert.ToInt32(Console.ReadLine());
int[] arr7 = new int[size];
Console.WriteLine("Enter elements of the array:");
for (int i = 0; i < size; i++)
    arr7[i] = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Array in reverse order:");
for (int i = size - 1; i >= 0; i--)
    Console.Write(arr7[i] + " ");




static bool IsPrime(int num)
{
    if (num <= 1)
        return false;
        
    for (int i = 2; i <= Math.Sqrt(num); i++)
    {
        if (num % i == 0)
            return false;
    }
    return true;
}

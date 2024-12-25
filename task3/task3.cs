/*
 * 1
 * when you pass by value you pass a copy from value or the array
 * so if you edit the value within the scope of the function it will use the value
 * that you give in the function but the original value will be the same, won't be touched
 * when you pass by reference you send the location of the value or the array
 * so you when you edit the value you edit the actual thing.
 * example
 */
int value = 10;
changeByValue(value);
Console.WriteLine(value);
changeByReference(ref value);
Console.WriteLine(value);
void changeByValue(int value)
{
    value = 20;
}

void changeByReference(ref int value)
{
    value = 20;
}

/*
 * 2
 * Passing Reference Type by Value
 * A copy of the reference (not the object) is passed to the method.
 * Changes to the object's properties affect the original object because the reference still points to the same memory location.
 * Reassigning the reference inside the method does not affect the original variable outside the method.
 * Passing Reference Type by Reference
 * The actual reference to the object is passed to the method using the ref keyword.
 * Changes to the object's properties and reassignments of the reference affect the original variable outside the method.
 */
MyClass objByValue = new MyClass { Value = 10 };
Console.WriteLine($"Before passing by value: {objByValue.Value}");
ModifyByValue(objByValue);
Console.WriteLine($"After passing by value: {objByValue.Value}");

// Passing by Reference
MyClass objByReference = new MyClass { Value = 10 };
Console.WriteLine($"Before passing by reference: {objByReference.Value}");
ModifyByReference(ref objByReference);
Console.WriteLine($"After passing by reference: {objByReference.Value}");
void ModifyByValue(MyClass obj)
{
    obj.Value = 20; // Modifies the object's property
    obj = new MyClass { Value = 30 }; // Reassigning reference does not affect the caller
}

void ModifyByReference(ref MyClass obj)
{
    obj.Value = 20; // Modifies the object's property
    obj = new MyClass { Value = 30 }; // Reassigning reference affects the caller
}
//3
(int sum, int sub)calc(int num, int num2, int num3, int num4)
{
    int sum = num + num2;
    int sub = num3 - num4;
    return (sum, sub);
}
//res is a tuple
var res=calc(10, 20, 30, 40);
Console.WriteLine(res);

//4
string s = "123";
Console.WriteLine("sum of the digits: "+sumDigits(s));
int sumDigits(string s)
{
    int sum = 0;
    foreach (char c in s)
    {
        sum += c - '0';
    }
    return sum;
}
//5
Console.WriteLine("the number is prime: "+IsPrime(5));
bool IsPrime(int num)
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
//6
int[] arr = {11, 2, 3, 4, 1, 6, 700, 8, 9, 10};
int min = 0, max = 0;
MinMax(arr, ref min, ref max);
Console.WriteLine(min);
Console.WriteLine(max);
void MinMax(int[] arr, ref int min, ref int max)
{
    min = arr[0];
    max = arr[0];
    foreach (var i in arr)
    {
        min = i < min ? i : min;
        max = i > max ? i : max;
    }
}
//7
Console.Write("enter number: ");
int number = Convert.ToInt32(Console.ReadLine());
try
{
    long factor = fact(number);
    Console.WriteLine(factor);
}
catch (ArgumentException e)
{
    Console.WriteLine(e);
    throw;
}

long fact(int num)
{
    if (num < 0)
        throw new ArgumentOutOfRangeException("undefined");
    long res = 1;
    for (int i = 1; i <= num; i++)
    {
        res *= i;
    }
    return res;
}
//8
string ss = "Rashad";
Console.WriteLine(changeChar(ss, 'r', 1));
string changeChar(string s, char newC, int index=0)
{
    char[] ss = s.ToCharArray();
    ss[index] = newC;
    return new string(ss);
}


class MyClass
{
    public int Value { get; set; }
}


 

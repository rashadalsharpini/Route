//1
Console.Write("enter a number: ");
string input = Console.ReadLine();
Console.WriteLine(input);
//2
int num = int.Parse(Console.ReadLine());
Console.WriteLine(num);
//3
double x=5.4;
double y=3.7;
Console.WriteLine(x*y);
//4
string s = "0123456789";
Console.WriteLine(s.Substring(2, 4));
//5
int value=10;
int value2=value;
value=20;
Console.WriteLine("value:"+value);
Console.WriteLine("value2:"+value2);
//6
MyClass obj=new MyClass();
obj.number=10;
MyClass obj2 = obj;
obj.number=20;
Console.WriteLine(obj2.number);
Console.WriteLine(obj.number);
//they will print the same values because they are a reference from each other
//7
string fName=Console.ReadLine();
string lName=Console.ReadLine();
Console.WriteLine(fName+lName);
//8
Console.Write("enter principal: ");
double principal=double.Parse(Console.ReadLine());
Console.Write("enter rate: ");
double rate=double.Parse(Console.ReadLine());
Console.Write("enter time: ");
double time = double.Parse(Console.ReadLine());
Console.WriteLine("Interest: "+ (principal * rate * time) / 100);
//9
Console.Write("enter weight: ");
double weight=double.Parse(Console.ReadLine());
Console.Write("enter height: ");
double height = double.Parse(Console.ReadLine());
Console.WriteLine("BMI: "+weight/(height*height));
//10
int temp = 25; 
string result=temp<10?"Just cold":temp>30?"Just hot":"Good";
Console.WriteLine("result: "+result);
//11
Console.Write("enter day: ");
string day=Console.ReadLine();
Console.Write("enter month: ");
string month=Console.ReadLine();
Console.Write("enter year: ");
string year=Console.ReadLine();
Console.WriteLine($"Today's date : {day}, {month}, {year}");
Console.WriteLine($"Today's date : {day} / {month} / {year}");
Console.WriteLine($"Today's date : {day} – {month} – {year}");
//12
//C  The event is on 06/14/2024
//13
//A value 1 will be assigned to d.
//14
//6 1
//15
//7 7
class MyClass {
    public int number;
}

using ConsoleApp2;
Console.Write("enter x: ");
double x = Convert.ToDouble(Console.ReadLine());
Console.Write("enter y: ");
double y = Convert.ToDouble(Console.ReadLine());
Console.Write("enter z: ");
double z = Convert.ToDouble(Console.ReadLine());
Point p1 = new Point(x, y, z);
Point p2 = new Point(4, 5, 6);
Console.WriteLine(p1);
Console.WriteLine(p2);
/*
 * the == wouldn't work because it can't compare objects it compares values
 * in order to such a thing we should overload the operator, and we didn't take yet
 * but i will implement it any way
 * for some reason the ide forced me to implement the != too
 * i don't know why he wouldn't run without it
 * and sort wouldn't run without adding these two line to compareto
 *         if(ReferenceEquals(a, b)) return true;
        if(ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
 */
if (p1==p2)
    Console.WriteLine("match");
else 
    Console.WriteLine("doesn't match");
    
    
Point[] arr = new Point[] { p1, p2, new Point(6, 7, 8), new Point(6, 6, 9) }; 

Array.Sort(arr);

foreach(Point p in arr)
    Console.WriteLine(p);
    

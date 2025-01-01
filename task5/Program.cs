using ConsoleApp1;

#region 1
Person[] persons = new Person[3];
persons[0]= new Person{Name="rashad", Age=22};
persons[1]= new Person{Name="Yousef", Age=19};
persons[2]= new Person{Name="Sayed", Age=30};
foreach (var person in persons)
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
#endregion

#region 2
Point p1 = new Point{X=1,Y=2};
Point p2 = new Point{X=2,Y=3};
Console.WriteLine(Point.Distance(p1,p2));
#endregion

#region 3
Person dump = new Person();
for (int i =0; i < persons.Length-1; i++)
    dump = persons[i].Age>persons[i+1].Age? persons[i]: persons[i+1];
Console.WriteLine($"Name: {dump.Name}, Age: {dump.Age}");
#endregion
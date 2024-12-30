using ConsoleApp1;
//part 2
//1
foreach(string day in Enum.GetNames(typeof(weekday)))
    Console.WriteLine(day);
  
//2
Console.Write("enter season: (spring, summer, autumn, winter)");
bool season = Enum.TryParse(Console.ReadLine(), true, out Season seasos);
if (season)
{
    switch (seasos)
    {
        case Season.Spring:
            Console.WriteLine("Spring: March to May");
            break;
        case Season.Summer:
            Console.WriteLine("Summer: June to August");
            break;
        case Season.Autumn:
            Console.WriteLine("Autumn: September to November");
            break;
        case Season.Winter:
            Console.WriteLine("Winter: December to February");
            break;
        default:
            Console.WriteLine("Invalid season.");
            break;
    }
}
//3
Permissions userPermissions = Permissions.None;

// Add permissions
userPermissions |= Permissions.Read;
userPermissions |= Permissions.Write;

Console.WriteLine("Current Permissions: " + userPermissions);

// Check if a specific permission exists
if ((userPermissions & Permissions.Read) == Permissions.Read)
{
    Console.WriteLine("Read permission is granted.");
}

if ((userPermissions & Permissions.Execute) != Permissions.Execute)
{
    Console.WriteLine("Execute permission is NOT granted.");
}

// Remove a permission
userPermissions &= ~Permissions.Write;
Console.WriteLine("Updated Permissions: " + userPermissions);

// Check if a specific permission exists after removal
if ((userPermissions & Permissions.Write) == Permissions.Write)
{
    Console.WriteLine("Write permission is granted.");
}
else
{
    Console.WriteLine("Write permission is NOT granted.");
}

//4
Console.Write("Enter color: ");
bool isParsed = Enum.TryParse(Console.ReadLine(), true, out Colors color);
if (isParsed)
    Console.WriteLine($"{color} is a primary color.");
else
    Console.WriteLine("The entered color is not a primary color.");

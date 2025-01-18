using ConsoleApp2;

Employee[] empArray = new Employee[3];
HiringDate hire1 = new HiringDate(15, 5, 2020);
HiringDate hire2 = new HiringDate(30, 3, 2019);
HiringDate hire3 = new HiringDate(20, 8, 2021);
empArray[0] = new Employee(1, "rashad", 12000, 'm', SecurityLevel.developer,hire1 );
empArray[1] = new Employee(2, "sayd", 14000, 'm', SecurityLevel.SecurityOfficer,hire2 );
empArray[2] = new Employee(3, "fatma", 13000, 'f', SecurityLevel.secretary,hire3 );

Array.Sort(empArray, (x, y) => CompareHiringDate(x.HiringDate, y.HiringDate));
foreach (var emp in empArray)
{
    Console.WriteLine(emp);
}

Console.WriteLine("\nBoxing and Unboxing: 0 occurrences (no value types were boxed/unboxed).");
int CompareHiringDate(HiringDate date1, HiringDate date2)
{
    if (date1.year != date2.year)
        return date1.year.CompareTo(date2.year);
    if (date1.month != date2.month)
        return date1.month.CompareTo(date2.month);
    return date1.day.CompareTo(date2.day);
}
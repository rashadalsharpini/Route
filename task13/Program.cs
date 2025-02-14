Department IT = new() { DeptID = 1, DeptName = "IT" };
Club companyClub = new() { ClubID = 1, ClubName = "Company Club" };

Employee emp1 = new() { EmployeeId = 101, BirthDate = new DateTime(1955, 1, 1), VacationStock = 3 };
Employee emp2 = new() { EmployeeId = 102, BirthDate = new DateTime(1990, 5, 10), VacationStock = 5 };
SalesPerson sales = new() { EmployeeId = 103, AchievedTarget = 50 };
BoardMember board = new() { EmployeeId = 104 };

// Add employees to Department & Club
IT.AddStaff(emp1);
IT.AddStaff(emp2);
IT.AddStaff(sales);
IT.AddStaff(board);

companyClub.AddMember(emp1);
companyClub.AddMember(emp2);
companyClub.AddMember(sales);
companyClub.AddMember(board);

// Fire Events
emp1.RequestVacation(new DateTime(2025, 6, 1), new DateTime(2025, 6, 10)); // Exceeds vacation days
emp2.EndOfYearOperation(); // Not too old
emp1.EndOfYearOperation(); // Over 60 → Layoff

sales.CheckTarget(60); // Sales target not met → Layoff
board.Resign(); // Board Member Resigns → Layoff

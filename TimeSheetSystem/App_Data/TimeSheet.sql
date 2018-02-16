CREATE TABLE [dbo].[TimeSheet]
(
	[EmployeeNo] INT NOT NULL PRIMARY KEY, 
    [TimeIn] TIME NOT NULL, 
    [TimeOut] TIME NOT NULL, 
    [BreakOut] TIME NOT NULL, 
    [BreakIn] TIME NOT NULL, 
    [HoursWorked] TIME NOT NULL
)
